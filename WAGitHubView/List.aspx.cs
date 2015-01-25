using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Globalization;

namespace WebAppGitHubView
{
    public partial class List : System.Web.UI.Page
    {
        string pattern = @"(([a-z0-9\-\.]+)?[a-z0-9\-]+(!?\.[a-z]{2,4}))";
        Regex reg;
        GitHubUrlContext dhuc;
        IPStatus status;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.regUrl.CssClass = "validation_error";

                dhuc = new GitHubUrlContext();
                SelectGridView(dhuc);
            
                message.Text = String.Empty;
                if (!IsPostBack)
                {
                    this.tb_url.Value = String.Empty;
                    tb_url.Disabled = true;
                }
            }
            catch (Exception ex)
            {
                this.message.Text = ex.Message;
            }
        }

        void GridViewUrl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Style.Add("text-align", "center;");
                e.Row.Cells[0].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                e.Row.Attributes.Add("onclick", "cell_list_Click(this," + e.Row.Cells[0].Text + ")");
                e.Row.Cells[0].Visible = false;
                e.Row.CssClass = "rowRepository";
            }
        }

        private void SelectGridView(GitHubUrlContext gitHubUrlContext)
        {
            try
            {
                SqlDataSourceUrl.ConnectionString = gitHubUrlContext.Database.Connection.ConnectionString;
                SqlDataSourceUrl.SelectCommand = "SELECT * FROM [URLS]";
                GridViewUrl.DataSourceID = SqlDataSourceUrl.ID;
                GridViewUrl.RowDataBound += GridViewUrl_RowDataBound;
            }
            catch (Exception ex)
            {
                message.Text = ex.Message;
            }
            finally
            {
                gitHubUrlContext.Dispose();
            }
        }

        private void DisabledTexBox()
        {
            tb_url.Value = String.Empty;
            tb_url.Disabled = true;
            this.btActivation.Text = "ACTIVATION";
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            if (!this.tb_url.Disabled)
            {
                Ping p = new Ping();
                PingReply pr = p.Send(@"github.com");
                status = pr.Status;
                reg = new Regex(pattern);

                try
                {
                    if (status == IPStatus.Success && tb_url.Value.Length > 0 &&
                    reg.Match(tb_url.Value, 0).Value == "github.com")
                    {
                        try
                        {
                            dhuc = new GitHubUrlContext();
                            using (SqlConnection conn = new SqlConnection(dhuc.Database.Connection.ConnectionString))
                            {
                                string query = String.Format(CultureInfo.InvariantCulture,"INSERT INTO [URLS] VALUES ('{0}')", tb_url.Value);
                                SqlCommand com = new SqlCommand(query, conn);
                                conn.Open();
                                if (com.ExecuteNonQuery() == 1)
                                {
                                    SelectGridView(dhuc);
                                    DisabledTexBox();
                                    message.CssClass = "validation_success";
                                    message.Text = "add url github.com";

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DisabledTexBox();
                            message.CssClass = "validation_error";
                            message.Text = ex.Message;
                        }
                    }
                }
                catch (Exception expt)
                {
                    DisabledTexBox();
                    message.CssClass = "validation_error";
                    message.Text = expt.Message;
                }
            }
            else
            {
                DisabledTexBox();
                message.CssClass = "validation_error";
                message.Text = "tex box disabled";
            }
        }

        protected void btRemove_Click(object sender, EventArgs e)
        {
            if (!this.tb_url.Disabled)
            {
                try
                {
                    dhuc = new GitHubUrlContext();
                    using (SqlConnection conn = new SqlConnection(dhuc.Database.Connection.ConnectionString))
                    {
                        string query = String.Format(CultureInfo.InvariantCulture,"DELETE FROM [URLS] WHERE [URLS].[Id] = {0}", this.hdField.Value);
                        SqlCommand com = new SqlCommand(query, conn);
                        conn.Open();
                        if (com.ExecuteNonQuery() == 1)
                        {
                            SelectGridView(dhuc);
                            DisabledTexBox();
                            message.CssClass = "validation_success";
                            message.Text = "removed url";

                        }
                    }
                }
                catch (Exception ex)
                {
                    DisabledTexBox();
                    message.CssClass = "validation_error";
                    message.Text = ex.Message;
                }
            }
            else
            {
                DisabledTexBox();
                message.CssClass = "validation_error";
                message.Text = "tex box disabled";
            }
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            if (!this.tb_url.Disabled)
            {
                try
                {
                    dhuc = new GitHubUrlContext();
                    using (SqlConnection conn = new SqlConnection(dhuc.Database.Connection.ConnectionString))
                    {
                        string query = String.Format(CultureInfo.InvariantCulture,"UPDATE [URLS] SET [Url] = '{0}' WHERE Id = {1};", this.tb_url.Value, this.hdField.Value);
                        SqlCommand com = new SqlCommand(query, conn);
                        conn.Open();
                        if (com.ExecuteNonQuery() == 1)
                        {
                            SelectGridView(dhuc);
                            DisabledTexBox();
                            message.CssClass = "validation_success";
                            message.Text = "edit url";
                        }
                    }
                }
                catch (Exception ex)
                {
                    DisabledTexBox();
                    message.CssClass = "validation_error";
                    message.Text = ex.Message;
                }
            }
            else
            {
                DisabledTexBox();
                message.CssClass = "validation_error";
                message.Text = "tex box disabled";
            }
        }

        protected void btActivation_Click(object sender, EventArgs e)
        {
            if (this.tb_url.Disabled)
            {
                this.tb_url.Disabled = false;
                this.btActivation.Text = "DISABLED";
            }
            else
            {
                this.tb_url.Disabled = true;
                this.btActivation.Text = "ACTIVATION";
            }
        }
    }
}
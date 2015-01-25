using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Octokit;
using System.Data.SqlClient;
using System.Globalization;

namespace WebAppGitHubView
{
    public partial class Show : System.Web.UI.Page
    {
        string token = "2a5ca5df4d9adc3318ce632a9394f8353e853ab4";

        protected void Page_Load(object sender, EventArgs e)
        {
            //int countUrl = Convert.ToInt32(Request.QueryString["cu"], CultureInfo.InvariantCulture);

            try
            {
                using (GitHubUrlContext context = new GitHubUrlContext())
                {
                    using (SqlConnection conn = new SqlConnection(context.Database.Connection.ConnectionString))
                    {
                        string query = String.Format(CultureInfo.InvariantCulture, "SELECT [URLS].[Url] FROM [URLS]");
                        SqlCommand com = new SqlCommand(query, conn);
                        conn.Open();
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            Uri uri;
                            while (reader.Read())
                            {
                                uri = new Uri((string)reader[0]);
                                string[] res = uri.Segments;
                                GetInfo(res[1].Substring(0, res[1].Length - 1), res[2]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message.Text = ex.Message;
                
            }

        }

        private async void GetInfo(string user, string repository)
        {
            try
            {
                var github = new GitHubClient(new ProductHeaderValue("MyPubToken"));
                github.Credentials = new Credentials(token);


                IReadOnlyList<Branch> branches; IRepositoryCommitsClient client; IReadOnlyList<GitHubCommit> listCommit;
                CommitRequest request;

                Panel panelRepository; Panel panelBranch; Panel panelCommit;

                System.Web.UI.WebControls.Label labelRepository; System.Web.UI.WebControls.Label labelBranch;
                System.Web.UI.WebControls.Label labelCommit;
                HyperLink link;
                BulletedList comList; ListItem autor; ListItem date; int id_lb = 0;

                panelRepository = new Panel();
                panelRepository.CssClass = "repository";
                this.container.Controls.Add(panelRepository);

                labelRepository = new System.Web.UI.WebControls.Label();
                labelRepository.ID = "lb_repository" + id_lb++;
                labelRepository.CssClass = "";
                labelRepository.Text = "<h2>" + repository + " repository" + "</h2>";
                panelRepository.Controls.Add(labelRepository);

                branches = await github.Repository.GetAllBranches(user, repository);
                client = github.Repository.Commits;

                for (int b = 0; b < branches.Count; b++)
                {
                    panelBranch = new Panel();
                    panelBranch.CssClass = "branch";
                    panelRepository.Controls.Add(panelBranch);

                    labelBranch = new System.Web.UI.WebControls.Label();
                    labelBranch.ID = "lb_branch" + b;
                    labelBranch.CssClass = "";
                    labelBranch.Text = "<h3>" + branches[b].Name + " branch" + "</h3>";
                    panelBranch.Controls.Add(labelBranch);

                    request = new CommitRequest { Sha = branches[b].Commit.Sha };
                    listCommit = await client.GetAll(user, repository, request);

                    for (int c = 0; c < listCommit.Count; c++)
                    {
                        if (listCommit.Count <= c) break;
                        panelCommit = new Panel();
                        panelCommit.CssClass = "commit";
                        panelBranch.Controls.Add(panelCommit);

                        link = new HyperLink();
                        link.ID = "link_commit" + c;
                        link.CssClass = "link";
                        link.NavigateUrl = listCommit[c].HtmlUrl;
                        link.Text = listCommit[c].Commit.Message + " commit";

                        labelCommit = new System.Web.UI.WebControls.Label();
                        labelCommit.ID = "lb_commit" + c;
                        labelCommit.CssClass = "";
                        labelCommit.Text = "<h4> </h4>";
                        labelCommit.Controls.Add(link);
                        panelCommit.Controls.Add(labelCommit);

                        comList = new BulletedList();
                        comList.ID = "list_commit" + c;
                        comList.CssClass = "comlist";
                        comList.BulletStyle = BulletStyle.NotSet;
                        comList.DisplayMode = BulletedListDisplayMode.Text;

                        autor = new ListItem("Autor = " + listCommit[c].Commit.Author.Name);
                        comList.Items.Add(autor);
                        date = new ListItem("Date = " + listCommit[c].Commit.Author.Date);
                        comList.Items.Add(date);

                        panelCommit.Controls.Add(comList);
                    }
                }
            }
            catch (Exception ex)
            {
                message.Text = ex.Message;
            }

        }

        protected void bt_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx", false);
        }
    }
}
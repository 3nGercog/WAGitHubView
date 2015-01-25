using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Octokit;

namespace WebAppGitHubView
{
    public partial class Second : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string repository = Request.QueryString["name"];
                    string user = Request.QueryString["user"];
                    Page.Title = "Commit Info";
                    //Response.Write("name repository  - " + repository + "  owner - " + user);
                    if (!String.IsNullOrEmpty(repository) && !String.IsNullOrEmpty(user))
                        GetInfo(user, repository);
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
                h1.InnerText = repository;
                GitHubClient github = (GitHubClient)(Session["GitHub"]);
                var branches = await github.Repository.GetAllBranches(user, repository);
                var client = github.Repository.Commits;
                System.Web.UI.WebControls.Label labelBranch;
                System.Web.UI.WebControls.Label labelCommit;
                BulletedList list;
                ListItem itemMessage;
                ListItem itemSha;
                ListItem itemUrl;
                ListItem itemDate;

                int countBranch = 0;

                foreach (var item in branches)
                {
                    labelBranch = new System.Web.UI.WebControls.Label();
                    labelBranch.ID = "labelBranch" + countBranch++;

                    labelBranch.Text = "<h2>" + item.Name + " branch" + "</h2>";

                    commitInfo.Controls.Add(labelBranch);

                    var request = new CommitRequest { Sha = item.Commit.Sha };
                    var listCommits = await client.GetAll(user, repository, request);
                    int val = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (listCommits.Count <= i)
                            break;
                        labelCommit = new System.Web.UI.WebControls.Label();
                        labelCommit.ID = "labelCommit" + i;
                        labelCommit.Text = "        <h4>" + listCommits[i].Commit.Message + " commit</h4>";

                        commitInfo.Controls.Add(labelCommit);

                        list = new BulletedList();
                        list.ID = "listItem" + i;
                        list.Attributes.Add("class", "commit");
                        list.BulletStyle = BulletStyle.Circle;
                        //list.BulletImageUrl = "~/Image/apple-touch-icon-144.png";
                        list.DisplayMode = BulletedListDisplayMode.Text;
                        ++val;
                        itemMessage = new ListItem("Login:   " + listCommits[i].Author.Login, val.ToString());

                        list.Items.Add(itemMessage);
                        ++val;
                        itemSha = new ListItem("Sha:   " + listCommits[i].Sha, val.ToString());
                        list.Items.Add(itemSha);
                        itemUrl = new ListItem("Url:   " + listCommits[i].Url, listCommits[i].HtmlUrl);
                        list.Items.Add(itemUrl);
                        ++val;
                        itemDate = new ListItem("Date:   " + listCommits[i].Commit.Committer.Date, val.ToString());
                        list.Items.Add(itemDate);

                        commitInfo.Controls.Add(list);
                    }
                }
            }
            catch (Exception ex)
            {
                message.Text = ex.Message;
            }
            
        }
    }
}
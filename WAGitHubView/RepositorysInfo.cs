using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Globalization;

namespace WebAppGitHubView
{
    public class RepositorysInfo
    {
        ReadOnlyCollection<string> _FirstColum;
        Collection<string> _SecondColum;

        string[] firstColum = null;
        string[] secondColum = null;

        public RepositorysInfo(string[] secondColum)
        {
            _SecondColum = new Collection<string>(secondColum);
        }
        public RepositorysInfo(string name, string fullName, string description, string url, int id, DateTime date)
        {
            firstColum = new string[] { "NAME", "FULLNAME", "DESCRIPTION", "URL", "ID", "DATE" };
            _FirstColum = new ReadOnlyCollection<string>(firstColum);
            secondColum = new string[firstColum.Length];
            secondColum[0] = name;
            secondColum[1] = fullName;
            secondColum[2] = description;
            secondColum[3] = url;
            secondColum[4] = id.ToString(CultureInfo.InvariantCulture);
            secondColum[5] = date.ToString();
            _SecondColum = new Collection<string>(secondColum);
        }
        public ReadOnlyCollection<string> FirstColum
        {
            get { return _FirstColum; }
        }
        public Collection<string> SecondColum
        {
            get { return _SecondColum; }
        }
    }
}


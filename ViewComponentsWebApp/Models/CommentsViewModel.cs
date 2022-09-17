using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ViewComponentsWebApp.Models
{
    public class CommentsViewModel
    {
        public int CommentCount { get; set; }
        public string Comment { get; set; }
        public string Content { get; set; }

       // public List<ContentList> ContentList { get; set; }

    }

    //public class ContentList
    //{
    //    public string ContentName { get; set; }
        
    //}
}

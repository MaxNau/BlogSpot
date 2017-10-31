using BlogSpot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BlogSpot.Extensions
{
    public static class ActionLinkExtensions
    {
        public static MvcHtmlString PostLink(this HtmlHelper helper, Post post)
        {
            return helper.ActionLink(post.Tiltle, "Post", "Blog",
                new
                {
                    year = post.PostedOn.Year,
                    month = post.PostedOn.Month,
                    title = post.Slug
                },
                new
                {
                    title = post.Tiltle
                });
        }

        public static MvcHtmlString CategoryLink(this HtmlHelper helper,
            Category category)
        {
            if (category != null)
            {
                return helper.ActionLink(category.Name, "Category", "Blog",
                    new
                    {
                        category = category.Slug
                    },
                    new
                    {
                        title = string.Format("See all posts in {0}", category.Name)
                    });
            }
            else
            {
                return null;
            }
        }

        public static MvcHtmlString TagLink(this HtmlHelper helper, Tag tag)
        {
            return helper.ActionLink(tag.Name, "Tag", "Blog", new { tag = tag.Slug },
                new
                {
                    title = string.Format("See all posts in {0}", tag.Name)
                });
        }
    }
}

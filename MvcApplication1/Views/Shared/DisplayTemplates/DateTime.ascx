<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.DateTime?>" %>   
<%=Html.Raw((Model.HasValue ? Model.Value.ToShortDateString() : string.Empty)) %>
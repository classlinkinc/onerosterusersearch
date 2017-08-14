using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OneRosterUserSearch.Objects
{
    internal class OneRoster
    {
        public string SourcedId { get; set; }
        public string Status { get; set; }
        public DateTime DateLastModified { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Role { get; set; }
        public string Identifier { get; set; }
        public string Email { get; set; }
        public string Sms { get; set; }
        public string Phone { get; set; }

        [JsonProperty("demographics")]
        public Demographics DemographicsObject { get; set; }
        [JsonIgnore]
        public string Demographics => $"href: {DemographicsObject?.Href} sourcedid: {DemographicsObject?.SourcedId} type: {DemographicsObject?.Type}";

        [JsonProperty("metadata")]
        public Metadata MetadataObject { get; set; }
        [JsonIgnore]
        public string Metadata => $"grade: {MetadataObject.Grade}";

        [JsonProperty("orgs")]
        public List<Orgs> OrgsObject { get; set; }
        [JsonIgnore]
        public string Orgs => OrgsObject.Aggregate(string.Empty, (current, org) => current + $"[href: {org?.Href} sourcedId: {org?.SourcedId} type: {org?.Type}]");
    }


    internal class Class
    {
        public string SourcedId { get; set; }
        public string Status { get; set; }
        public DateTime DateLastModified { get; set; }
        public string Title { get; set; }
        public string ClassCode { get; set; }
        public string ClassType { get; set; }
        public string Location { get; set; }
        public string[] Grades { get; set; }
        public string[] Subjects { get; set; }

        [JsonProperty("course")]
        public Course CourseObject { get; set; }
        [JsonIgnore]
        public string Course => $"href: {CourseObject.Href} sourcedid: {CourseObject.SourcedId} type: {CourseObject.Type}";

        [JsonProperty("school")]
        public School SchoolObject { get; set; }
        [JsonIgnore]
        public string School => $"href: {SchoolObject.Href} sourcedid: {SchoolObject.SourcedId} type: {SchoolObject.Type}";

        [JsonProperty("terms")]
        public List<Terms> TermsObject { get; set; }
        [JsonIgnore]
        public string Terms => TermsObject.Aggregate(string.Empty, (current, term) => current + $"[href: {term.Href} sourcedId: {term.SourcedId} type: {term.Type}]");

        [JsonIgnore]
        public OneRosterUserList TeacherList { get; set; }
    }

    internal class Course
    {
        public string Href { get; set; }
        public string SourcedId { get; set; }
        public string Type { get; set; }
    }

    internal class School
    {
        public string Href { get; set; }
        public string SourcedId { get; set; }
        public string Type { get; set; }
    }

    internal class Terms
    {
        public string Href { get; set; }
        public string SourcedId { get; set; }
        public string Type { get; set; }
    }

    internal class Demographics
    {
        public string Href { get; set; }
        public string SourcedId { get; set; }
        public string Type { get; set; }
    }

    internal class Metadata
    {
        public string Grade { get; set; }
    }

    internal class Orgs
    {
        public string Href { get; set; }
        public string SourcedId { get; set; }
        public string Type { get; set; }
    }

    internal class OneRosterUserList
    {
        [JsonProperty("users")]
        public IList<OneRoster> oneRosterUserList { get; set; }
    }

    internal class ClassList
    {
        [JsonProperty("classes")]
        public IList<Class> classList { get; set; }
    }
}

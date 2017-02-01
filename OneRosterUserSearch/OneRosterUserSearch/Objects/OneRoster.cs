using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OneRosterUserSearch.Objects
{
    internal class OneRoster
    {
        public string sourcedId { get; set; }
        public string status { get; set; }
        public DateTime dateLastModified { get; set; }
        public string username { get; set; }
        public string userId { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string role { get; set; }
        public string identifier { get; set; }
        public string email { get; set; }
        public string sms { get; set; }
        public string phone { get; set; }

        [JsonProperty("demographics")]
        public Demographics demographicsObject { get; set; }
        [JsonIgnore]
        public string demographics => $"href: {demographicsObject.href} sourcedid: {demographicsObject.sourcedId} type: {demographicsObject.type}";

        [JsonProperty("metadata")]
        public Metadata metadataObject { get; set; }
        [JsonIgnore]
        public string metadata => $"grade: {metadataObject.grade}";

        [JsonProperty("orgs")]
        public List<Orgs> orgsObject { get; set; }
        [JsonIgnore]
        public string orgs => orgsObject.Aggregate(string.Empty, (current, org) => current + $"[href: {org.href} sourcedId: {org.sourcedId} type: {org.type}]");
    }


    internal class Class
    {
        public string sourcedId { get; set; }
        public string status { get; set; }
        public DateTime dateLastModified { get; set; }
        public string title { get; set; }
        public string classCode { get; set; }
        public string classType { get; set; }
        public string location { get; set; }
        public string grade { get; set; }
        public string subjects { get; set; }

        [JsonProperty("course")]
        public Course courseObject { get; set; }
        [JsonIgnore]
        public string course => $"href: {courseObject.href} sourcedid: {courseObject.sourcedId} type: {courseObject.type}";

        [JsonProperty("school")]
        public School schoolObject { get; set; }
        [JsonIgnore]
        public string school => $"href: {schoolObject.href} sourcedid: {schoolObject.sourcedId} type: {schoolObject.type}";

        [JsonProperty("terms")]
        public List<Terms> termsObject { get; set; }
        [JsonIgnore]
        public string terms => termsObject.Aggregate(string.Empty, (current, term) => current + $"[href: {term.href} sourcedId: {term.sourcedId} type: {term.type}]");

        [JsonIgnore]
        public OneRosterUserList teacherList { get; set; }
    }

    internal class Course
    {
        public string href { get; set; }
        public string sourcedId { get; set; }
        public string type { get; set; }
    }

    internal class School
    {
        public string href { get; set; }
        public string sourcedId { get; set; }
        public string type { get; set; }
    }

    internal class Terms
    {
        public string href { get; set; }
        public string sourcedId { get; set; }
        public string type { get; set; }
    }

    internal class Demographics
    {
        public string href { get; set; }
        public string sourcedId { get; set; }
        public string type { get; set; }
    }

    internal class Metadata
    {
        public string grade { get; set; }
    }

    internal class Orgs
    {
        public string href { get; set; }
        public string sourcedId { get; set; }
        public string type { get; set; }
    }

    internal class OneRosterUserList
    {
        [JsonProperty("users")]
        public List<OneRoster> oneRosterUserList { get; set; }
    }

    internal class ClassList
    {
        [JsonProperty("classes")]
        public List<Class> classList { get; set; }
    }
}

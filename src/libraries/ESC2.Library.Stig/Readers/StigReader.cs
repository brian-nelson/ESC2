using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using ESC2.Library.Stig.Interfaces;
using ESC2.Library.Stig.Objects;
using Group = ESC2.Library.Stig.Objects.Group;

namespace ESC2.Library.Stig.Readers
{
    public class StigReader : IStigReader
    {
        private readonly XmlDocument _xml;
        private readonly XmlElement _xmlDoc;
        private readonly XmlNamespaceManager _namespaceManager;
        private readonly string _filename;

        public StigReader(string filename)
        {
            _xml = new XmlDocument();
            _xml.Load(filename);
            _xmlDoc = _xml.DocumentElement;
            _namespaceManager = new XmlNamespaceManager(_xml.NameTable);
            _namespaceManager.AddNamespace("xccdf", _xmlDoc.NamespaceURI);
            _namespaceManager.AddNamespace("dc", _xmlDoc.Attributes["xmlns:dc"].Value);
            _filename = filename;
        }

        public StigReader(Stream stream, string filename)
        {
            TextReader reader = new StreamReader(stream);
            string xml = reader.ReadToEnd();

            _xml = new XmlDocument();
            _xml.LoadXml(xml);
            _xmlDoc = _xml.DocumentElement;
            _namespaceManager = new XmlNamespaceManager(_xml.NameTable);
            _namespaceManager.AddNamespace("xccdf", _xmlDoc.NamespaceURI);
            _namespaceManager.AddNamespace("dc", _xmlDoc.Attributes["xmlns:dc"].Value);
            _filename = filename;
        }

        public Benchmark GetBenchmark()
        {
            var output = new Benchmark();

            output.Id = _xmlDoc.Attributes["id"].InnerText;

            var statusNode = _xmlDoc.SelectSingleNode("descendant::xccdf:status", _namespaceManager);
            if (statusNode != null)
            {
                output.StatusDate = DateTime.Parse(statusNode.Attributes["date"].Value);
                output.Status = statusNode.InnerText;
            }

            var titleNode = _xmlDoc.SelectSingleNode("descendant::xccdf:title", _namespaceManager);
            if (titleNode != null)
            {
                output.Title = titleNode.InnerText;
            }

            var descriptionNode = _xmlDoc.SelectSingleNode("descendant::xccdf:description", _namespaceManager);
            if (descriptionNode != null)
            {
                output.Description = descriptionNode.InnerText;
            }

            var referenceNode = _xmlDoc.SelectSingleNode("descendant::xccdf:reference", _namespaceManager);
            if (referenceNode != null)
            {
                output.ReferenceHref = referenceNode.Attributes["href"]?.Value;

                var publisherNode = referenceNode.SelectSingleNode("descendant::dc:publisher", _namespaceManager);
                if (publisherNode != null)
                {
                    output.Publisher = publisherNode.InnerText;
                }

                var sourceNode = referenceNode.SelectSingleNode("descendant::dc:source", _namespaceManager);
                if (sourceNode != null)
                {
                    output.Source = sourceNode.InnerText;
                }
            }

            var versionNode = _xmlDoc.SelectSingleNode("descendant::xccdf:version", _namespaceManager);
            if (versionNode != null)
            {
                output.Version = versionNode.InnerText;
            }

            var plainTextNodes = _xmlDoc.SelectNodes("descendant::xccdf:plain-text", _namespaceManager);
            foreach (XmlElement plainTextNode in plainTextNodes)
            {
                string id = plainTextNode.Attributes["id"]?.Value;

                if (id != null)
                {
                    if (id == "release-info")
                    {
                        output.ReleaseInfo = plainTextNode.InnerText;
                    }
                    else if (id == "generator")
                    {
                        output.Generator = plainTextNode.InnerText;
                    }
                    else if (id == "conventionsVersion")
                    {
                        output.ConventionsVersion = plainTextNode.InnerText;
                    }
                }
            }

            output.Filename = Path.GetFileName(_filename);

            return output;
        }

        public List<Group> GetGroups()
        {
            var output = new List<Group>();

            var groups = _xmlDoc.SelectNodes("descendant::xccdf:Group", _namespaceManager);
            foreach (XmlElement groupNode in groups)
            {
                var group = new Group
                {
                    Id = groupNode.Attributes["id"]?.Value
                };

                var titleNode = groupNode.SelectSingleNode("descendant::xccdf:title", _namespaceManager);
                if (titleNode != null)
                {
                    group.Title = titleNode.InnerText;
                }

                group.Rules = GetRules(groupNode);
                
                output.Add(group);
            }

            return output;
        }

        private List<Rule> GetRules(XmlElement groupNode)
        {
            var output = new List<Rule>();

            var rules = groupNode.SelectNodes("descendant::xccdf:Rule", _namespaceManager);
            foreach (XmlElement ruleNode in rules)
            {
                var rule = new Rule
                {
                    Id = ruleNode.Attributes["id"]?.Value,
                    Weight = Double.Parse(ruleNode.Attributes["weight"]?.Value ?? "0"),
                    Severity = ruleNode.Attributes["severity"]?.Value ?? "high"
                };

                var versionNode = ruleNode.SelectSingleNode("descendant::xccdf:version", _namespaceManager);
                if (versionNode != null)
                {
                    rule.Version = versionNode.InnerText;
                }
                
                var titleNode = ruleNode.SelectSingleNode("descendant::xccdf:title", _namespaceManager);
                if (titleNode != null)
                {
                    rule.Title = titleNode.InnerText;
                }

                var descriptionNode = ruleNode.SelectSingleNode("descendant::xccdf:description", _namespaceManager);
                if (descriptionNode != null)
                {

                    var temp = descriptionNode.InnerText.Replace("&lt;", "<");
                    temp = temp.Replace("&gt;", ">");

                    var matches = Regex.Matches(temp, "<VulnDiscussion>(?<value>[^<>]*)</VulnDiscussion>");

                    if (matches.Count>0)
                    {
                        var group = matches[0].Groups[1];
                        rule.Discussion = group.Value;
                    }
                }

                var referenceNode = ruleNode.SelectSingleNode("descendant::xccdf:reference", _namespaceManager);
                
                var identNode = ruleNode.SelectSingleNode("descendant::xccdf:ident", _namespaceManager);
                if (identNode != null)
                {
                    rule.CCI = identNode.InnerText;
                }

                var fixTextNode = ruleNode.SelectSingleNode("descendant::xccdf:fixtext", _namespaceManager);
                if (fixTextNode != null)
                {
                    rule.Fix = fixTextNode.InnerText;
                }

                var checkNode = ruleNode.SelectSingleNode("descendant::xccdf:check", _namespaceManager);
                if (checkNode != null)
                {
                    var checkContentNode = checkNode.SelectSingleNode("descendant::xccdf:check-content", _namespaceManager);
                    if (checkContentNode != null)
                    {
                        rule.Check = checkNode.InnerText;
                    }
                }

                output.Add(rule);
            }

            return output;
        }
    }
}

using MunicipalServices.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MunicipalServices.Data
{
    public class IssueRepository
    {
        private static readonly List<Issue> _issues = new();
        private static int _nextId = 1;

        public IEnumerable<Issue> GetAll() => _issues;

        public Issue? Get(int id) => _issues.FirstOrDefault(i => i.Id == id);

        public Issue Add(Issue issue)
        {
            issue.Id = _nextId++;
            issue.ReferenceNumber = $"REF-{DateTime.Now:yyyyMMdd}-{issue.Id:D4}";
            _issues.Add(issue);
            return issue;
        }
    }
}
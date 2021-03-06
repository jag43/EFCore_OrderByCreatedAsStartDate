﻿using IncorrectSyntaxNearTheKeywordAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS
{
    public class TestDataInserter
    {
        private readonly DataContext _context;

        public TestDataInserter(DataContext context)
        {
            _context = context;
        }

        public async Task InsertTestDataAsync()
        {
            var job = new TelemJob();
            _context.TelemJobs.Add(job);

            var jobSupplier = new TelemJobSupplier
            {
                Job = job
            };
            _context.TelemJobSuppliers.Add(jobSupplier);

            var stack = new TelemCallStack
            {
                JobSupplier = jobSupplier
            };
            _context.TelemCallStacks.Add(stack);

            var calls = new TelemCall[]
            {
                new TelemCall
                {
                    CallStack = stack
                }
            };
            await _context.TelemCalls.AddRangeAsync(calls);

            await _context.SaveChangesAsync();
        }
    }
}

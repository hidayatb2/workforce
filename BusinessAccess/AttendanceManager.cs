using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class AttendanceManager
    {
        private readonly AttendanceRepository repository;

        public AttendanceManager(AttendanceRepository repository)
        {
            this.repository = repository;
        }
    }
}

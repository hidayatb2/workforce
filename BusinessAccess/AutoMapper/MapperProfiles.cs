using AutoMapper;
using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{

    sealed class BidMapProfile : Profile
    {
        public BidMapProfile()
        {
            CreateMap<BidRequest, Bid>();
            CreateMap<Bid, BidRequest>();
        }
    }

    sealed class AdminMapProfile : Profile
    {
        public AdminMapProfile()
        {
            CreateMap<AdminRequest, User>();
           // CreateMap<Bid, BidRequest>();
        }
    }


}

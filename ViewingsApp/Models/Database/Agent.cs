using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ViewingsApp.Models.Database
{
    public class Agent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public bool IsFreeAt(DateTime viewingStartTime)
        {
            if(viewingStartTime.Hour < StartTime || viewingStartTime.Hour > EndTime)
            {
                return false;
            }
            return true;
        }
    }
}
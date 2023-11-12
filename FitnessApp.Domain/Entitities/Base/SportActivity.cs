﻿using FitnessApp.Domain.CustomTypes;

namespace FitnessApp.Domain.Entities.Base
{
    public class SportActivity
    {
        public Guid Id { get; set; }
        public double Distance { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public DateTime ActivityDate { get; set; }
        public Feeling Feeling { get; set; }
        public virtual string DistanceUnit => "";

        public User User { get; set; }
        public int UserId { get; set; }
    }
}

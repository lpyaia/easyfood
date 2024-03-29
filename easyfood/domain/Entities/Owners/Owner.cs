﻿using Easyfood.Domain.Entities.Partners;
using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities.Owners
{
    public class Owner : BaseEntity
    {
        public Name FirstName { get; private set; }

        public Name LastName { get; private set; }

        public Guid UserId { get; private set; }

        public List<Partner> Partners { get; private set; }

        private Owner()
        {
        }

        public Owner(string firstName, string lastName, Guid userId)
        {
            FirstName = new Name(firstName);
            LastName = new Name(lastName);
            UserId = userId;
            Partners = new List<Partner>();
        }
    }
}
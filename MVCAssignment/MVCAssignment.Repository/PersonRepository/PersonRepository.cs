using MVCAssignment.Model;
using MVCAssignment.Model.Enum;
using MVCAssignment.Repository.DTOs;

namespace MVCAssignment.Repository.PersonRepository
{
    public class PersonRepository : IPersonRepository
    {
        public List<Person> _people { get; set; }

        public Guid? AddPerson(Person person)
        {
            _people.Add(person);
            return person.Id;
        }

        public bool UpdatePerson(Person person)
        {
            var another = _people.FirstOrDefault(p => p.Id == person.Id);
            if (another != null)
            {
                another = person;
                return true;
            }
            return false;
        }

        public bool DeletePerson(Guid personId)
        {
            var another = _people.FirstOrDefault(p => p.Id == personId);
            if (another != null)
            {
                _people.Remove(another);
                return true;
            }
            return false;
        }

        public List<Person> GetPeople(FilterPersonDto filter)
        {
            var people = GenerateData();

            if (filter.Gender.HasValue)
            {
                people = people.Where(p => p.Gender == filter.Gender.Value).ToList();
            }
            if (filter.Year.HasValue)
            {
                people = people.Where(p => p.DOB.Year == filter.Year.Value).ToList();
            }
            if (filter.BeforeYear.HasValue)
            {
                people = people.Where(p => p.DOB.Year < filter.BeforeYear.Value).ToList();
            }
            if (filter.AfterYear.HasValue)
            {
                people = people.Where(p => p.DOB.Year > filter.AfterYear.Value).ToList();
            }
            if (filter.IsGraduated.HasValue)
            {
                people = people.Where(p => p.IsGraduated == filter.IsGraduated.Value).ToList();
            }

            return people;
        }
        public List<Person> GenerateData()
        {
            var people = new List<Person>();
            for (int i = 0; i < 20; i++)
            {
                people.Add(new Person
                {
                    Id = Guid.NewGuid(),
                    FirstName = $"First Name {i + 1}",
                    LastName = $"Last Name {i + 1}",
                    Gender = (i % 2 == 0) ? Gender.Male : Gender.Female,
                    DOB = DateTime.Now.AddYears(-(20 + i)), // Random DOBs within 20 years
                    PhoneNumber = $"123-456-{i:0000}", // Formatted phone number
                    BirthPlace = $"City {i + 1}, State",
                    IsGraduated = (i % 3 == 0) // Set IsGraduated for some entries
                });
            }
            return people;
        }

        public Person GetOldestPerson()
        {
            var people = GenerateData();
            return people.OrderByDescending(p => p.DOB.Year).FirstOrDefault();
        }

        public List<string> GetFulName()
        {
            var people = GenerateData();

            return people.Select(p => p.FirstName + " " + p.LastName).ToList();
        }
    }
}

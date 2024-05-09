using ManhPT_APIAssignment2.Model;
using ManhPT_APIAssignment2.Model.Enum;

namespace ManhPT_APIAssignment2.Repository.PersonRepository
{
    public class PersonRepository : IPersonRepository
    {

        public static readonly List<Person> _people = new()
            {

                new ("Manh", "Phan", Gender.Male, new DateTime(2002, 02, 22),  "Ha Noi"),
                new ("Duc", "Hoang", Gender.Male, new DateTime(1996, 01, 11), "Ha Tay"),
                new ("Hai", "Luong", Gender.Male, new DateTime(2001, 06, 21),  "Ninh Binh"),
                new ("Ha", "Phan", Gender.Female, new DateTime(1995, 05, 12),  "Bac Giang"),
                new ("Dat", "Tuan", Gender.Male, new DateTime(2000, 08, 15), "Bac Ninh"),
                new ("Hieu", "Nguyen", Gender.Male, new DateTime(2002, 03, 07), "Ha Noi"),
                new ("Duc", "Nguyen", Gender.Female, new DateTime(2002, 02, 15), "Ha Noi"),
                new ("Hieu", "Pham", Gender.Male, new DateTime(2002, 03, 16), "Ha Nam"),
                new ("Hoang", "Nguyen", Gender.Female, new DateTime(2002, 01, 01), "Hai Phong"),
            };


        public async Task<bool> AddPersonAsync(Person person)
        {
            _people.Add(person);
            return true;
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            var another = _people.FirstOrDefault(p => p.Id == person.Id);
            if (another != null)
            {
                _people.Remove(another);
                _people.Add(person);
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePersonAsync(Guid personId)
        {
            var another = _people.FirstOrDefault(p => p.Id == personId);
            if (another != null)
            {
                _people.Remove(another);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync(FilterPersonDto filter)
        {
            var people = _people.AsQueryable(); // Use AsQueryable for deferred execution and better chaining

            if (!string.IsNullOrEmpty(filter.Name))
            {
                people = people.Where(p => (p.FirstName + " " + p.LastName).Contains(filter.Name));
            }
            if (filter.Gender.HasValue && filter.Gender != 0)
            {
                people = people.Where(p => p.Gender == filter.Gender.Value);
            }

            if (!string.IsNullOrEmpty(filter.BirthPlace))
            {
                people = people.Where(p => p.BirthPlace == filter.BirthPlace);
            }

            return await Task.FromResult(people.ToList());
        }

        public async Task<Person?> GetPersonByIdAsync(Guid personId)
        {
            var person = _people.FirstOrDefault(p => p.Id == personId);
            if (person != null)
            {
                return person;
            }
            else
            {
                return null;
            }
        }
    }
}

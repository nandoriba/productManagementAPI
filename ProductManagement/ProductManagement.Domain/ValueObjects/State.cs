using ProductManagement.Domain.Exceptions;

namespace ProductManagement.Domain.ValueObjects
{
    public class State : Enumeration
    {
        public static State Active = new State(1, nameof(Active).ToLowerInvariant());
        public static State Inactive = new State(2, nameof(Inactive).ToLowerInvariant());

        public State(int id, string name)
            : base(id, name)
        { }

        public static IEnumerable<State> List() =>
            new[] { Active, Inactive };

        public static State FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new ProductManagementException($"Possible values for State: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static State From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ProductManagementException($"Possible values for State: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}

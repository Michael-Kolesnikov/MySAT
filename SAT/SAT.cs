namespace MySAT
{
    public static class SAT
    {
        public static string[] Start(string path)
        {
            List<List<int>> clauses = ParseDIMACS(path);
            List<int> assignement = new();
            if (DPLL(clauses, assignement)) 
            {
                return new string[] { "SAT", string.Join(' ', assignement) };

            }
            else
            {
                return new string[] { "UNSAT" };
            }
        }

        private static List<List<int>> ParseDIMACS(string path)
        {
            List<List<int>> clauses;
            using (var streamReader = new StreamReader(path))
            {
                clauses = new List<List<int>>();
                string? line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line[0] == 'c') continue;
                    if (line[0] == 'p') continue;
                    clauses.Add(new List<int>(line.Split(' ').Where(c => c != string.Empty && c != "0").Select(c => int.Parse(c)).ToList()));
                }
            }
            return clauses;
        }

        public static bool DPLL(List<List<int>> clauses, List<int> assignment)
        {
            // Unit propagation
            List<int> unitLiterals = clauses.Where(clause => clause.Count == 1).Select(c => c[0]).ToList();
            unitLiterals.ForEach(literal =>
            {
                clauses.RemoveAll(clause => clause.Contains(literal));
                clauses.ForEach(clause => clause.Remove(-literal));
            });
            assignment.AddRange(unitLiterals);

            // Pure literals elimination

            // Find all literals in the clauses
            var literals = clauses.SelectMany(c => c).Distinct().ToList();
            // Find all pure literals in the clauses
            var pureLiterals = literals.GroupBy(l => Math.Abs(l)).Where(g => g.Count() == 1).SelectMany(g => g).ToList();
            assignment.AddRange(pureLiterals);
            // Delete clauses contained pure literals
            pureLiterals.ForEach(literal => clauses.RemoveAll(clause => clause.Contains(literal)));

            // Check for empty clause
            if (clauses.Any(clause => clause.Count == 0)) return false;

            // Check for no clause left
            if (clauses.Count == 0) return true;

            var chosenLiteral = clauses.SelectMany(c => c).FirstOrDefault();
            var clausesAddTrue = new List<List<int>>();
            var clausesAddFalse = new List<List<int>>();
            var assigmentCopy = new List<int>(assignment);
            foreach (var clause in clauses)
            {
                clausesAddTrue.Add(new List<int>(clause));
            }

            clausesAddTrue.Add(new List<int> { chosenLiteral});
            if (DPLL(clausesAddTrue, assignment)) return true;

            foreach (var clause in clauses)
            {
                clausesAddFalse.Add(new List<int>(clause));
            }
            clausesAddFalse.Add(new List<int> { -chosenLiteral });
            if (DPLL(clausesAddFalse, assignment)) return true;

            return false;
        }
    }
}

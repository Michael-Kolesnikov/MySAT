namespace SAT
{
    public static class SAT
    {
        private static int numberOfVariables;

        public static void Start(string file)
        {
            if (DPLL(ParseDIMACS(file)))
                Console.WriteLine("SAT");
            else
                Console.WriteLine("UNSAT");
        }

        private static List<List<int?>> ParseDIMACS(string file)
        {
            List<List<int?>> clauses = new();

            // Line Breaking
            var lines = file.Split('\n');

            // Get number of variables
            SAT.numberOfVariables = int.Parse(lines[1].Split(' ')[2]);

            // Get clauses
            for (var i = 2; i < lines.Length; i++)
            {
                List<int?> clause = new();
                var clauseElements = lines[i].Split(' ').ToList();
                clauseElements.Remove("0");
                for (var j = 0; j < clauseElements.Count; j++)
                    clause.Add(int.Parse(clauseElements[j]));

                clauses.Add(clause);
            }

            return clauses;
        }

        private static bool DPLL(List<List<int?>> clauses)
        {
            // unit-propagate
            while (true)
            {
                int singleLiteral = 0;

                // find singleLiteral
                foreach (var clause in clauses)
                {
                    if (clause.Count != 1 && clause[0] != null) continue;
                    singleLiteral = clause[0] ?? 0;
                    break;
                }

                // if singleLiteral is not found break
                if (singleLiteral == 0) break;

                // remove clause if contains literal, remove -literal if contains -literal
                var clausesLength = clauses.Count;
                var clausesOffset = 0;
                for (var i = 0; i < clausesLength; i++, clausesOffset++)
                {
                    var clause = clauses[clausesOffset];
                    if (clause.Contains(singleLiteral))
                    {
                        clauses.Remove(clause);
                        clausesOffset--;
                    }

                    if (clause.Contains(-singleLiteral))
                        // if clause contains single -literal it's mean that clauses contains a and not a, this is lead to unsat. To define that clause must contains null element
                        if (clause.Count == 1)
                        {
                            clause.Clear();
                            clause.Add(null);
                        }
                        else
                            clause.Remove(-singleLiteral);
                }
            }

            // pure-literal-assign
            // looking for the same literals
            List<int> sameLiterals = new();
            for (var i = 1; i <= numberOfVariables; i++)
            {
                var literal = i;
                var isContains = false;
                var isContainsInv = false;
                foreach (var clause in clauses)
                {
                    if (clause.Contains(literal))
                        isContains = true;
                    if (clause.Contains(-literal))
                        isContainsInv = true;
                }

                if (isContains ^ isContainsInv)
                    sameLiterals.Add(literal);
            }

            if (sameLiterals.Count != 0 && clauses.Count != 1)
                for (var i = 0; i < sameLiterals.Count; i++)
                {
                    var literal = sameLiterals[i];
                    foreach (var clause in clauses)
                        if (clause.Contains(literal))
                            clause.Remove(literal);
                }

            // if clauses is empty then return true(SAT)
            if (clauses.Count == 0)
                return true;

            // if set of clauses contains nill
            foreach (var clause in clauses)
                if (clause.Contains(null))
                    return false;

            // choose unassigned literal
            var chosenLiteral = 0;
            foreach (var clause in clauses)
                if (clause.Count != 0 && clause[0] is not null)
                {
                    chosenLiteral = clause[0] ?? 0;
                    break;
                }

            // try assigning the chosen literal to true
            var extendedTrueClauses = new List<List<int?>>(clauses) { new List<int?>() { chosenLiteral } };
            if (DPLL(extendedTrueClauses)) return true;

            // try assigning the chosen literal to false
            var extendedFalseClauses = new List<List<int?>>(clauses) { new List<int?>() { -chosenLiteral } };
            if (DPLL(extendedFalseClauses)) return true;

            return false;
        }
    }
}

# MySAT
SAT решатель на основе DPLL
## Как использовать
```c#
  var path = "...";
  string[] result = SAT.Start(path);
  // result[0] — SAT/UNSAT
  // result[1] — набор литералов, которые должны быть истины. Существует только для SAT 
```

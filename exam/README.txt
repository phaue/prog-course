I have implemented the Cholesky-Banaschiewicz & the Cholesky-Crout algorithms.
I have also implemented a function that generates a real symmetric positive-definite matrix of size n. Along with a function that can generate a random vector of size n.
I have implemented the linear equation solver, calculation of determinant and calculation of the inverse matrix.

I have tested these implementations in main_implementations.cs where the result of this testing can be seen in Out_test.txt.
I have made it possible to alter the size of the matrix subject to the tests through the Makefile.

Then i have tried to see if either of Cholesky-Banaschiewicz or Cholesky-Crout method was to be preferred by timing calculations of large randomly generated matrices.
For the sizes tested there is no clear advantage of either, they are equally good on random matrices.
The ranges for testing the algorithms can be changed in the makefile.
It is also shown that they follow the 1/3*n^3 trend that was expected from the wiki article.
# Exploring the New Blazor App in .NET 8

While working on a project, I learned a lot and discovered both strengths and areas for improvement. Here are my takeaways:

## Areas for Improvement:

1. **Data Access Logic:** 
   - One key improvement would be to remove data access logic from the controllers.

2. **DTOs:**
   - Using reasonable DTOs can improve data exchange.

3. **Pages:**
   - Reordering pages logically, correctly dividing those who can do with just SSR and those that actually need to be interactive.

4. **HTTP Calls Optimization:**
   - Eliminate unnecessary HTTP calls in the SSR pages.

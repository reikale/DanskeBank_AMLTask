# DanskeBank AML Tribe Interview Task

###  Running the API
- Before building this project
  - Use Entity Core Migration to create necessary tables (Nuget Entity framework core tools)
    ``` Migration
     PM> Add-Migration <YourNameMigration>
     PM> Update-Database
     ```
  - The TaxRules and TaxType tables should populate with initial values, but for further testing I recommend to add some additional data to the database:
    - Municipalities table: Add at least 1 municipality, select relevant values for the TaxRule
    - Taxes table: Add at least 1 tax to table to be able to test the  API
 

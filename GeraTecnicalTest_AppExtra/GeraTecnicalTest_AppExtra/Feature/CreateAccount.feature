Feature: CreateAccount


@smoke
Scenario: Create Account Succesfully
	Given I accessed the identification page
	When I identify myself for my first purchase
		| BaseEmail       | EmailProvider |
		| thiago.grespi90 | gmail.com     |
	And I click the Continuar button
	And I access the second step to create my account
	And fill all the information to create my account
		| AccountType  | FullName      | Document       | PhoneType | PhoneDDD | Phone      | Phone2Type  | Phone2DDD | Phone2    | Pass       | BirthdateDay | BirthdateMonth | BirthdateYear | Gender    |
		| PessoaFisica | Thiago Grespi | 482.483.700-62 | Celular   | 16       | 991223456  | Residencial | 16        | 37214590  | Senha@2020 | 25           | 07             | 1990          | Masculino |
	When click the Continuar button
	Then the Cart page should be displayed with no items on it




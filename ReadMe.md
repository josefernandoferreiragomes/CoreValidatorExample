# Scope
	Create a validation engine for a WorkFlow engine

## Constraints
	Should be extendable
	To be used in different WorkFlows
	Validation rules might be the same in differnt flows
	Should be simple and easy to use by newcomers

## Steps
Create a solution with Web Site, business layer, and Web API

Investigate and create 3 simplified PoCs, one for each alternative.
1) Specific WF Managers with reusable validators, using factory pattern
2) Generic Validators configured per WF Manager
3) Chain of responsibility pattern

Create testers for each

## Sources
	https://dotnetchris.wordpress.com/2009/02/11/creating-a-generic-validation-framework/
	(has some bugs, corrected with check in number 2)

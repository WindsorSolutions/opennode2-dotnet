select * from NAccountAuthRequest

update NAccountAuthRequest set AuthorizationAccountId=null, AuthorizationComments=null, AuthorizationGeneratedOn=null 

update NAccountAuthRequest set NAASAccount='tkconrad@gmail.com', FullName='TK Conrad', EmailAddress='tkconrad@gmail.com'

select * from NAccountAuthRequestFlow

select * from NAccount where NAASAccount like('tk%')

select * from NAccountPolicy where AccountId='_5702B403-6DAC-4261-B59D-23A7A5A669ED'

select * from NAccount where NAASAccount='tkconrad@gmail.com'

select * from NAccount
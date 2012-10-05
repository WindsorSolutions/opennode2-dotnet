select * from NSERVICE

select * from NSERVICEARG

select * from NFlow

SELECT s.Id, s.Name, s.FlowId, s.IsActive, s.ServiceType, s.Implementor, s.AuthLevel, s.ModifiedBy, s.ModifiedOn, f.Code 
FROM NService s, NFlow f 
WHERE s.IsActive = 'Y' AND f.Id = s.FlowId
ORDER BY f.Code, s.Name
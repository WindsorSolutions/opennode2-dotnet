-- Update FrequencyType values to new format
update NSchedule set FrequencyType='Minutes' where FrequencyType like('Minute%');
update NSchedule set FrequencyType='Hours' where FrequencyType like('Hour%');
update NSchedule set FrequencyType='Days' where FrequencyType like('Day%');
update NSchedule set FrequencyType='Weeks' where FrequencyType like('Week%');
update NSchedule set FrequencyType='Months' where FrequencyType like('Month%');

commit;
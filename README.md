# ColeParmerCC
MVP
</br>
</br>
Progress</br>
I was able to compute the difference in time for the entry pair in the TripUploadEvents. The function is very limited/short</br>
sighted. It does not take into account multiple pairs from different sensors.</br>
As for calculating the total time in alarm in the TripUploadData, I was able to query some information. The resulting list</br>
does not take into account the actual ranges; the information being recorded where it exceeds the limit, THEN </br>
re-enters the specified range. As of now, only the data that exceeds the Max specified by sensor2 are listed and computed.</br>
This would have be fun to tinker with, but I did not have time due to work constraints. 
</br>
</br>
Approach:
</br> 
(TripUploadEvent)
</br>
Ideally, to account for more than one exit/entry pair. I had wanted to create a dictionary that had a Key of 'string' (the</br>
the sensor name), the value would be a 'List' of the object type 'DeviceAlarmVM' in chronological order specific to</br>
that sensor. I would iterate through the sensor list (all unique), and then retrieve and iterate through the value of the specified</br>
sensor. I would look for matching sets via EventType(6-8, 7-9), compute and keep track of the difference and time for the specific event type.
</br>
(TripUploadData)
</br>
I wanted to query the information specific to the the sensor. In order to do so, I would have used a more refined query to get a list</br>
that included the correct ranges, which would have provided a more accurate time. Given that I would have had a sorted list</br>
I would have been able to compute the difference by iterating through and adding the difference to a variable. I would've reported</br>
the time spent in alarm whether it exceeded the Max and/or Min for each sensor. 
</br>


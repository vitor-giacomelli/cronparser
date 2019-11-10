# CronParser

This is a Console C# application that will parse a valid Cron date format and print it in the screen in the following format:

minute 30

hour 10 11 12 13

day of month 1 2 3 4 5 6 7 8 9 10 12 13 14 15 16 17 18 19 20 21 22 23

24 25 26 27 28 29 30 31

Month 1 2 3 4 5 6 7 8 9 10 11 12

day of week 3 5

It considers either * or ? as all possible values.

# Valid Input
The input should be typed in the following order and format:

minute hour day-of-month month day-of-week

i.e.

10 1-5 5-10 * mon,thu,sun

## Minute
Valid Integer

i.e: 

10

## Hour
Valid integers separated by a single hyphen (no spaces), * or ?

i.e: 

1-5

?

## Day of Month
Valid integers separated by a single hyphen (no spaces), * or ?

i.e: 

5-10

?


## Month
Valid integers separated by a single hyphen (no spaces), * or ?

i.e: 

1-10

?



## Day of Week
Valid weekday names in english, separated by a single comma (no spaces). The case is irrelevant.

i.e: 

monday,tuesday,fri,sun

Sun,Friday,Thu

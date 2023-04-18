
DELETE FROM equipment;
DELETE FROM trainers;
DELETE FROM staff;
DELETE FROM customers;
DELETE FROM trainingSession;
DELETE FROM gym; 


INSERT INTO gym VALUES (
00001,
'123 Mainstreet NW',
'Calgary',
'Alberta',
'T3Z1B2'
);

INSERT INTO gym VALUES (
00002,
'1301 16 Ave NW',
'Calgary',
'Alberta',
'T2M0L4'
);

INSERT INTO gym VALUES (
00003,
'5150 North Road',
'Regina',
'Saskatoon',
'S0K0Y0'
);

INSERT INTO gym VALUES (
00004,
'101 55st',
'DinosaurCity',
'NEWFOUNDLAND',
'B1B1X1'
);

INSERT INTO gym VALUES (
00005,
'53 University Drive NW',
'Edmonton',
'Alberta',
'T3Z1B2'
);


INSERT INTO trainers VALUES(
1,
'Arnold',
'Schwarzenegger',
'1234567890',
'arnold@CPRGFitness.ca',
50000,
500,
'Seven time winner of Mr. Olympia',
true
);

INSERT INTO trainers VALUES(
2,
'Franco',
'Columbu',
'1234567890',
'Franco@CPRGFitness.ca',
40000,
400,
'Two time winner of Mr. Olympia',
true
);

INSERT INTO trainers VALUES(
3,
'Jean-Claude',
'Van Damme',
'1234567890',
'jean-claude@CPRGFitness.ca',
40000,
400,
'Muscles From Brussels',
true
);


INSERT INTO staff VALUES(
1,
1,
'Billy',
'Joel',
'7801234567',
'billy@CPRGFitness.ca',
30000,
'Front Desk',
true
);

INSERT INTO staff VALUES(
2,
1,
'Peter',
'Parker',
'7801234567',
'peter@CPRGFitness.ca',
30000,
'photographer',
true
);

INSERT INTO staff VALUES(
3,
2,
'Clark',
'Kent',
'7801234567',
'Clark@CPRGFitness.ca',
30000,
'Front Desk',
true
);

INSERT INTO staff VALUES(
4,
2,
'Bruce',
'Wayne',
'7801234567',
'bruce@CPRGFitness.ca',
30000,
'Janitor',
true
);

INSERT INTO staff VALUES(
5,
3,
'Harley',
'Quinn',
'7801234567',
'harley@CPRGFitness.ca',
30000,
'Accountant',
true
);

INSERT INTO staff VALUES(
6,
3,
'Poison',
'Ivy',
'7801234567',
'poison@CPRGFitness.ca',
30000,
'First Aid Attendand',
true
);

INSERT INTO staff VALUES(
7,
4,
'James',
'Howlett',
'7801234567',
'james@CPRGFitness.ca',
30000,
'Steroid dealer',
true
);

INSERT INTO staff VALUES(
8,
4,
'Charles',
'Xavier',
'7801234567',
'charles@CPRGFitness.ca',
30000,
'Front Desk',
true
);

INSERT INTO staff VALUES(
9,
5,
'Selina',
'Kyle',
'7801234567',
'selina@CPRGFitness.ca',
30000,
'Cat Wrangler',
true
);

INSERT INTO staff VALUES(
10,
5,
'Walter',
'White',
'7801234567',
'walter@CPRGFitness.ca',
30000,
'Chemist',
true
);

INSERT INTO customers VALUES(
1,
'John',
'Holloway',
'4038370000',
'john.holloway@edu.sait.ca',
'1977-06-11',
'Annual',
TRUE
);


INSERT INTO trainingsession VALUES(
1,
1,
1,
1,
'2023-04-27 15:00:00'
);


INSERT INTO equipment VALUES(
00001,
00001,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
00002,
00001,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
00003,
00001,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
00004,
00001,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
00005,
00001,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
00006,
00001,
'Dumbbell',
5
);
INSERT INTO equipment VALUES(
00007,
00001,
'Dumbbell',
10
);
INSERT INTO equipment VALUES(
00008,
00001,
'Dumbbell',
15
);
INSERT INTO equipment VALUES(
00009,
00001,
'Dumbbell',
20
);
INSERT INTO equipment VALUES(
00010,
00001,
'Dumbbell',
25
);
INSERT INTO equipment VALUES(
00011,
00001,
'Dumbbell',
30
);
INSERT INTO equipment VALUES(
00012,
00001,
'Dumbbell',
35
);
INSERT INTO equipment VALUES(
00013,
00001,
'Dumbbell',
40
);
INSERT INTO equipment VALUES(
00014,
00001,
'Dumbbell',
45
);
INSERT INTO equipment VALUES(
00015,
00001,
'Dumbbell',
50
);

INSERT INTO equipment VALUES(
16,
00002,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
17,
00002,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
18,
00002,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
19,
00002,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
20,
00002,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
21,
00002,
'Dumbbell',
5
);
INSERT INTO equipment VALUES(
22,
00002,
'Dumbbell',
10
);
INSERT INTO equipment VALUES(
23,
00002,
'Dumbbell',
15
);
INSERT INTO equipment VALUES(
24,
00002,
'Dumbbell',
20
);
INSERT INTO equipment VALUES(
25,
00002,
'Dumbbell',
25
);
INSERT INTO equipment VALUES(
26,
00002,
'Dumbbell',
30
);
INSERT INTO equipment VALUES(
27,
00002,
'Dumbbell',
35
);
INSERT INTO equipment VALUES(
28,
00002,
'Dumbbell',
40
);
INSERT INTO equipment VALUES(
29,
00002,
'Dumbbell',
45
);
INSERT INTO equipment VALUES(
30,
00002,
'Dumbbell',
50
);

INSERT INTO equipment VALUES(
31,
3,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
32,
3,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
33,
3,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
34,
3,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
35,
3,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
36,
3,
'Dumbbell',
5
);
INSERT INTO equipment VALUES(
37,
3,
'Dumbbell',
10
);
INSERT INTO equipment VALUES(
38,
3,
'Dumbbell',
15
);
INSERT INTO equipment VALUES(
39,
3,
'Dumbbell',
20
);
INSERT INTO equipment VALUES(
40,
3,
'Dumbbell',
25
);
INSERT INTO equipment VALUES(
41,
3,
'Barbell',
135
);
INSERT INTO equipment VALUES(
42,
3,
'Barbell',
135
);
INSERT INTO equipment VALUES(
43,
3,
'Barbell',
135
);
INSERT INTO equipment VALUES(
44,
3,
'Barbell',
135
);
INSERT INTO equipment VALUES(
45,
3,
'Barbell',
135
);

INSERT INTO equipment VALUES(
46,
4,
'BikeMachine',
NULL
);
INSERT INTO equipment VALUES(
47,
4,
'BikeMachine',
NULL
);
INSERT INTO equipment VALUES(
48,
4,
'BikeMachine',
NULL
);
INSERT INTO equipment VALUES(
49,
4,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
50,
4,
'Treadmill',
NULL
);
INSERT INTO equipment VALUES(
51,
4,
'Dumbbell',
5
);
INSERT INTO equipment VALUES(
52,
4,
'Dumbbell',
10
);
INSERT INTO equipment VALUES(
53,
4,
'Dumbbell',
15
);
INSERT INTO equipment VALUES(
54,
4,
'Dumbbell',
20
);
INSERT INTO equipment VALUES(
55,
4,
'Barbell',
225
);
INSERT INTO equipment VALUES(
56,
4,
'Barbell',
225
);
INSERT INTO equipment VALUES(
57,
4,
'Barbell',
225
);
INSERT INTO equipment VALUES(
58,
4,
'Barbell',
225
);
INSERT INTO equipment VALUES(
59,
4,
'Barbell',
225
);
INSERT INTO equipment VALUES(
60,
4,
'Barbell',
225
);

INSERT INTO equipment VALUES(
61,
5,
'BikeMachine',
NULL
);
INSERT INTO equipment VALUES(
62,
5,
'BikeMachine',
NULL
);
INSERT INTO equipment VALUES(
63,
5,
'BikeMachine',
NULL
);
INSERT INTO equipment VALUES(
64,
5,
'BikeMachine',
NULL
);
INSERT INTO equipment VALUES(
65,
5,
'BikeMachine',
NULL
);
INSERT INTO equipment VALUES(
66,
5,
'Barbell',
135
);
INSERT INTO equipment VALUES(
67,
5,
'Barbell',
135
);
INSERT INTO equipment VALUES(
68,
5,
'Barbell',
135
);
INSERT INTO equipment VALUES(
69,
5,
'Barbell',
135
);
INSERT INTO equipment VALUES(
70,
5,
'Barbell',
135
);
INSERT INTO equipment VALUES(
71,
5,
'Barbell',
225
);
INSERT INTO equipment VALUES(
72,
5,
'Barbell',
225
);
INSERT INTO equipment VALUES(
73,
5,
'Barbell',
225
);
INSERT INTO equipment VALUES(
74,
5,
'Barbell',
225
);
INSERT INTO equipment VALUES(
75,
5,
'Barbell',
225
);
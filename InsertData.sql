Insert into Users(Username, Email, FullName)
Values ('User1','user1@gmail.com','UserOne'),
('User2','user2@gmail.com','UserTwo'),
('User3','user3@gmail.com','UserThree');

INSERT INTO Posts (Title, Content, PublishedAt, UserId)
VALUES 
('Top 10 Street Foods in Vietnam', 'A list of must-try Vietnamese street food.', GETDATE(), 1),
('2025 Fashion Trends You Should Know', 'Let`s look at hot trend this year in fashion.', GETDATE(), 2),
('Best Movies to Watch This Summer', 'A curated list of exciting movies for your summer nights.', GETDATE(), 3);

INSERT INTO Comments (Text, CreatedAt, PostId, UserId)
VALUES 
('I love banh mi! Thanks for the list.', GETDATE(), 1, 2), 
('Can’t wait to try some of these!', GETDATE(), 1, 3),
('Totally agree with the oversized jacket trend!', GETDATE(), 2, 1),
('Looking forward to Dune 2!', GETDATE(), 3, 1);

INSERT INTO Tags (Name)
VALUES 
('Food'),
('Entertainment'),
('Fashion');

INSERT INTO PostTag (PostsPostId, TagsTagId)
VALUES 
(1, 1), -- Post 1 tagged with "Food"
(1, 2), -- Post 1 tagged with "Entertainment"
(2, 3); -- Post 2 tagged with "Fashion"

db = db.getSiblingDB('TaskListDb');

db.createCollection('Users');
db.Users.insertMany([
    { name: "User One" },
    { name: "User Two" },
    { name: "User Three" }
]);

db.createCollection('TaskLists');
db.TaskLists.insertMany([
{ name: "First Task List", ownerId: db.Users.findOne({name: "User One"})._id, tasks: ["Do laundry", "do grocery shopping"], sharedWithUsers: [], createdAt: new Date() },
    { name: "Second Task List", ownerId: db.Users.findOne({name: "User Two"})._id, tasks: ["Water plants"], sharedWithUsers: [db.Users.findOne({name: "User One"})._id.toString()], createdAt: new Date()},
    { name: "Third Task List", ownerId: db.Users.findOne({name: "User Three"})._id, tasks: [], sharedWithUsers: [], createdAt: new Date() }
]);

using Assignment3;
using Assignment3.Utility;
using NUnit.Framework.Constraints;

namespace LinkedListTests
{
    [TestFixture]
    public class LinkedListTests
    {
        private SLL list;
        [SetUp]
        public void Setup()
        {
            list = new SLL(); //creates a new singly linked list
        }

        //The Linked list is Empty
        [Test]
        public void IsEmpty_Initially_ReturnsTrue()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        //An item is Prepended
        [Test]
        public void AddFirst_WhenCalled_ItemIsPrepended()
        {
            var user = new User(1, "Prepend User", "prepend@example.com", "password");
            list.AddFirst(user);
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual(user, list.GetValue(0));
        }

        //An Item is Appended
        [Test]
        public void AddLast_WhenCalled_ItemIsAppended()
        {
            var firstUser = new User(1, "First User", "first@example.com", "password123");
            var LastUser = new User(2, "Append User", "append@example.com", "password");
            list.AddLast(LastUser);

            Assert.AreEqual(1, list.Count());
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual(LastUser, list.GetValue(0));
        }

        //An Item is Inserted at an Index
        [Test]
        public void Insert_AtSpecificIndex()
        {
            var firstUser = new User(1, "First User", "first@example.com", "password");
            var secondUser = new User(2, "Second User", "second@example.com", "password");
            list.AddFirst(firstUser);
            list.Add(secondUser, 1); // Insert at index 1
            Assert.AreEqual(secondUser, list.GetValue(1));
        }

        //An item is Replaced
        [Test]
        public void Replace_AtSpecificIndex_ItemIsReplaced()
        {
            var originalUser = new User(1, "Original User", "original@example.com", "password");
            var newUser = new User(2, "New User", "new@example.com", "password");
            list.AddFirst(originalUser);
            list.Replace(newUser, 0);
            Assert.AreEqual(newUser, list.GetValue(0));
        }

        //An item is deleted form the beginning of the list
        [Test]
        public void DeleteFirst_WhenCalled_FirstItemIsDeleted()
        {
            var user = new User(1, "Test User", "test@example.com", "password");
            var secondUser = new User(2, "Second User", "second@example.com", "password2");
            
            list.AddFirst(user);
            list.AddLast(secondUser);
            list.RemoveFirst();
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(secondUser, list.GetValue(0));
        }

        //An item is deleted from End of the list
        [Test]
        public void DeleteLast_WhenCalled_LastItemIsDeleted()
        {
            var firstUser = new User(1, "First User", "first@example.com", "password1");
            var user = new User(2, "Test User", "test@example.com", "password");
            
            list.AddFirst(firstUser);
            list.AddLast(user);
            list.RemoveLast();
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(firstUser, list.GetValue(0));
        }

        //An item is deleted from the Middle of the list
        [Test]
        public void Delete_AtMiddleIndex()
        {
            var firstUser = new User(1, "First User", "first@example.com", "password");
            var middleUser = new User(2, "Middle User", "middle@example.com", "password");
            var lastUser = new User(3, "Last User", "last@example.com", "password");
            list.AddLast(firstUser);
            list.AddLast(middleUser);
            list.AddLast(lastUser);
            list.Remove(1); // Remove the middle user index 1
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(lastUser, list.GetValue(1));
        }

        //An Existing Item is Found and retrieved
        [Test]
        public void Contains_WithExistingItem_ReturnsTrue()
        {
            var user = new User(1, "Existing User", "existing@example.com", "password");
            list.AddLast(user);

            // Ensure this user has EXACTLY the same property values as the one added to the list
            var sameUser = new User(1, "Existing User", "existing@example.com", "password");
            Assert.IsTrue(list.Contains(sameUser));
        }


        //Additional functionality reverse
        [Test]
        public void Reverse_WhenCalled_ListIsReversed()
        {
            var firstUser = new User(1, "First User", "first@example.com", "password");
            var secondUser = new User(2, "Second User", "second@example.com", "password");
            list.AddFirst(firstUser);
            list.AddLast(secondUser);
            list.Reverse();
            Assert.AreEqual(secondUser, list.GetValue(0));
            Assert.AreEqual(firstUser, list.GetValue(1));
        }







    }
}
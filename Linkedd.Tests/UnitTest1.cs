using NUnit.Framework;
using System;

namespace Linkedd.Tests
{
    public class Tests
    {


        [SetUp]
        public void Setup()
        {


        }



        [TestCase(new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 13)]
        [TestCase(new int[0] { }, 0)]
        [TestCase(new int[1] { 2 }, 1)]
        public void GetLenghtTest(int[] array, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.GetLenght();
            //assert
            Assert.AreEqual(actual, expected);
        }


        [TestCase(new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 })]
        [TestCase(new int[0] { }, new int[0] { })]
        [TestCase(new int[1] { 2 }, new int[1] { 2 })]
        public void ToArrayTest(int[] array, int[] expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int[] actual = linked.ToArray();
            //assert
            Assert.AreEqual(actual, expected);
        }


        [TestCase(new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, new int[14] { 78, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 78)]
        [TestCase(new int[0] { }, new int[1] { 3 }, 3)]
        [TestCase(new int[1] { 2 }, new int[2] { 5, 2 }, 5)]
        public void AddFirstTest(int[] array, int[] expected, int val)
        {
            //act
            LinkedList linked = new LinkedList(array);
            linked.AddFirst(val);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }

        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, new int[2] { 77, 88 }, new int[7] { 77, 88, 1, 2, 3, 4, 5 })]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, new int[1] { 77 }, new int[6] { 77, 1, 2, 3, 4, 5 })]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, new int[0] { }, new int[5] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[0] { }, new int[2] { 77, 88 }, new int[2] { 77, 88 })]

        public void AddFirstTest(int[] array, int[] array2, int[] expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            LinkedList linked2 = new LinkedList(array2);
            linked.AddFirst(linked2);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, new int[2] { 77, 88 }, 2, new int[7] { 1, 2, 77, 88, 3, 4, 5 })]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, new int[3] { 77, 88, 99 }, 1, new int[8] { 1, 77, 88, 99, 2, 3, 4, 5 })]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, new int[3] { 77, 88, 99 }, 0, new int[8] { 77, 88, 99, 1, 2, 3, 4, 5 })]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, new int[1] { 1 }, 4, new int[6] { 1, 2, 3, 4, 1, 5 })]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, new int[] {  }, 4, new int[5] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[1] { 1}, new int[2] { 55,44 }, 0, new int[3] { 55,44,1})]
       
        public void AddAtTest(int[] array, int[] array2, int idx, int[] expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            LinkedList linked2 = new LinkedList(array2);
            linked.AddAt(idx,linked2);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }
        

        [TestCase(new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },new int[14] { 1, 2, 78,3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 2, 78)]
        [TestCase(new int[4] { 1, 2, 3, 4 },new int[5] { 1,2,3,5,4}, 3,5)]
        [TestCase(new int[1] { 2 },new int[2] { 5,2 },0,5)]
        public void AddAtTest(int[] array, int[] expected, int idx, int val)
        {
            //act
            LinkedList linked = new LinkedList(array);
            linked.AddAt(idx, val);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }

        [TestCase(new int[3] { 5, 6, 5 }, 3, 2, "Индекс больше чем количество элементов")]
        [TestCase(new int[] { }, 0, 2, "Индекс больше чем количество элементов")]
        public void AddAtNegativeTest(int[] array, int idx, int val, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.AddAt(idx, val));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }





        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[6] { 1, 2, 3, 4, 5, 8888 }, 8888)]
        [TestCase(new int[0] { },new int[1] {5},5)]
        [TestCase(new int[1] { 2 },new int[2] { 2 ,5},5)]
        public void AddLastTest(int[] array, int[] expected, int val)
        {
            //act
            LinkedList linked = new LinkedList(array);
            linked.AddLast(val);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }
        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[2] { 77, 88 },new int[7] { 1, 2, 3, 4, 5, 77,88 })]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[1] { 77},new int[6] { 1, 2, 3, 4, 5, 77 })]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[0] {  },new int[5] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[0] {  },new int[2] {77,88  },new int[2] { 77,88 })]
        
        public void AddLastTest(int[] array,int[] array2, int[] expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            LinkedList linked2 = new LinkedList(array2);
            linked.AddLast(linked2);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }
        
        
        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[5] { 1, 2, 3333, 4, 5 }, 2, 3333)]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[5] { 444, 2, 3, 4, 5 }, 0, 444)]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[5] { 1, 2, 3, 4, 5555 }, 4, 5555)]
        [TestCase(new int[1] { 2 },new int[1] { 5},0,5)]
        public void SetTest(int[] array, int[] expected, int idx,int val)
        {
            //act
            LinkedList linked = new LinkedList(array);
            linked.Set(idx, val);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }

        [TestCase(new int[0] { }, 4, 1, "Индекс больше чем количество элементов")]
        [TestCase(new int[3] { 5,6,5}, 3,2, "Индекс больше чем количество элементов")]
        public void SetNegativeTest(int[] array, int idx, int val, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.Set(idx, val));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }


        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[4] { 1,2, 3, 4})]
        [TestCase(new int[1] { 2 },new int[0] { })]
        public void RemoveLastTest(int[] array, int[] expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            linked.RemoveLast();
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }

        [TestCase(new int[0] { }, "Нет элементов")]
        public void RemoveLastNegativeTest(int[] array, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.RemoveLast());
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }


        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[4] { 1,2, 3,5}, 3)]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[4] { 1,2, 3, 4} , 4 )]
        [TestCase(new int[1] { 2 },new int[0] {},0)]
        public void RemoveAtTest(int[] array, int[] expected, int idx)
        {
            //act
            LinkedList linked = new LinkedList(array);
            linked.RemoveAt(idx);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }

        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, 6, "Индекс за пределами")]
        [TestCase(new int[0] {}, 6, "Индекс за пределами")]
        [TestCase(new int[1] {1}, 1, "Индекс за пределами")]
        

        public void RemoveAtNegativeTest(int[] array, int idx, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.RemoveAt(idx));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }



        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[2] { 4,5}, 3)]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[5] { 1,2, 3, 4,5} ,0) ]        
        [TestCase(new int[1] { 2 },new int[0] { },1)]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, new int[0], 10)]

        public void RemoveFirstMultipleTest(int[] array, int[] expected, int n)
        {
            //act
            LinkedList linked = new LinkedList(array);
            linked.RemoveFirstMultiple(n);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }

        
        [TestCase(new int[0] { }, 2, "Нет элементов")]

        public void RemoveFirstMultipleNegativeTest(int[] array, int n, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.RemoveFirstMultiple(n));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }


        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[2] { 1,2}, 3)]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[5] { 1,2, 3, 4,5} ,0) ]
        [TestCase(new int[1] { 2 },new int[0] { },1)]
        
        public void RemoveLastMultipleTest(int[] array, int[] expected, int n)
        {
            //act
            LinkedList linked = new LinkedList(array);
            linked.RemoveLastMultiple(n);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }

        [TestCase(new int[0] { }, 2, "Нет элементов")]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, 10, "Нет элементов")]

        public void RemoveLastMultipleNegativeTest(int[] array, int n, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.RemoveLastMultiple(n));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }




        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[2] { 1,2}, 2,3)]        
        [TestCase(new int[14] { 1, 2, 3, 4, 5,6,7,8,9,10,11,12,13,14 },new int[5] {1,11,12,13,14} , 1,9 )]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[1] { 1} ,1,10) ]
        [TestCase(new int[1] { 2 },new int[0] { },0,1)]
        
        public void RemoveAtMultipleTest(int[] array, int[] expected, int idx, int n)
        {
            //act
            LinkedList linked = new LinkedList(array);
            linked.RemoveAtMultiple(idx, n);
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }

        [TestCase(new int[0] { },4,3, "Индекс за пределами")]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, 6, 3, "Индекс за пределами")]
        public void RemoveAtMultipleNegativeTest(int[] array, int idx, int n, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.RemoveAtMultiple(idx, n));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }



        
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, 3, 2)]
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, 6,0)]
        [TestCase(new int[5] { 5,6,3,4,6}, 6,1)]
        [TestCase(new int[1] { 2 },2,1)]
         public void RemoveFirstTest(int[] array, int n, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.RemoveFirst(n);
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[0] {  }, 5, "Нет элементов")]

        public void RemoveFirstNegativeTest(int[] array, int n, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.RemoveFirst(n));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestCase(new int[5] { 1, 2, 3, 4, 5 },new int[4] {2, 3, 4, 5 })]
        [TestCase(new int[1] { 1 },new int[0] {})]
               
         public void RemoveFirst1Test(int[] array, int[] expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            linked.RemoveFirst();
            //assert
            Assert.AreEqual(linked.ToArray(), expected);
        }

        [TestCase(new int[0] { }, "Нет элементов")]
        public void RemoveFirst1NegativeTest(int[] array, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.RemoveFirst());
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestCase(new int[5] { 3, 2, 3, 4, 3}, 3, 3)]
        [TestCase(new int[16] { 6, 2, 3, 4, 5 ,1, 2, 6, 4, 6, 1, 2,6,6,6,6 }, 6,7)]
        [TestCase(new int[1] { 2 },2,1)]
        [TestCase(new int[5] { 5, 6, 3, 4, 6 }, 66,0)]
        public void RemoveAllTest(int[] array, int n, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.RemoveAll(n);
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[0] { }, 3, "Нет элементов")]
        public void RemoveAllNegativeTest(int[] array, int val, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.RemoveAll(val));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }


        [TestCase(new int[5] { 3, 2, 3, 4, 3}, 3, true)]
        [TestCase(new int[16] { 6, 2, 3, 4, 5 ,1, 2, 6, 4, 6, 1, 2,6,6,6,6 }, 456,false)]
        [TestCase(new int[5] { 5,6,3,4,6}, 66,false)]
        [TestCase(new int[1] { 2 },2,true)]
         public void ContainsTest(int[] array, int n, bool expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            bool actual = linked.Contains(n);
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[0] { }, 3, "Нет элементов")]
        public void ContainsNegativeTest(int[] array, int val, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.Contains(val));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }


        [TestCase(new int[5] { 3, 2, 3, 4, 33}, 33, 4)]
        [TestCase(new int[16] { 5, 2, 3, 4, 5 ,1, 2, 6, 4, 6, 1, 2,6,6,6,6 }, 6,7)]
        [TestCase(new int[5] { 5,6,3,4,6}, 66,-1)]
        [TestCase(new int[1] { 2 },2,0)]
         public void IndexOfTest(int[] array, int n, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.IndexOf(n);
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[0] { }, 3, "Нет элементов")]
        public void IndexOfNegativeTest(int[] array, int val, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.IndexOf(val));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestCase(new int[5] { 3, 2, 3, 4, 33}, 4)]
        [TestCase(new int[16] { 5, 2, 3, 4, 56 ,1, 210, 6, 4, 6, 1, 2,6,6,6,6 }, 6)]
        [TestCase(new int[5] { 5,60,3,4,6}, 1)]
        [TestCase(new int[1] { 2 },0)]
         public void IndexOfMaxTest(int[] array, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.IndexOfMax();
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[0] { }, 3, "Нет элементов")]
        public void IndexOfMaxNegativeTest(int[] array, int val, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.IndexOfMax());
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }


        [TestCase(new int[5] { 3, 2, 3, 4, 33}, 1)]
        [TestCase(new int[6] { 5, 2, 3, 4, 56 ,1 }, 5)]
        [TestCase(new int[5] { 5,5,5,5,5}, 0)]
        [TestCase(new int[1] { 2 },0)]
         public void IndexOfMinTest(int[] array, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.IndexOfMin();
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[0] { }, 3, "Нет элементов")]
        public void IndexOfMinNegativeTest(int[] array, int val, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.IndexOfMin());
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestCase(new int[5] { 3, 2, 3, 4, 33}, 3)]
        [TestCase(new int[6] { 5, 2, 3, 4, 56 ,1 }, 5)]
        [TestCase(new int[5] { 5,5,5,5,5}, 5)]
        [TestCase(new int[1] { 2 },2)]
         public void GetFirstTest(int[] array, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.GetFirst();
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[0] { }, "Нет элементов")]
        public void GetFirstNegativeTest(int[] array, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.GetFirst());
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestCase(new int[5] { 3, 2, 3, 4, 33}, 33)]
        [TestCase(new int[6] { 5, 2, 3, 4, 56 ,1 }, 1)]
        [TestCase(new int[5] { 5,5,5,5,5}, 5)]        
        [TestCase(new int[1] { 2 },2)]
         public void GetLastTest(int[] array, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.GetLast();
            //assert
            Assert.AreEqual(actual, expected);
        }


        [TestCase(new int[0] { }, "Нет элементов")]

        public void GetLastNegativeTest(int[] array, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.GetLast());
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestCase(new int[5] { 3, 2, 3, 4, 33}, 4, 33)]
        [TestCase(new int[5] { 5,5,5,5,5}, 0,5)]
        [TestCase(new int[1] { 2 },0, 2)]
        [TestCase(new int[6] { 5, 2, 3, 4, 56, 1 }, 10, -1)]
        public void GetTest(int[] array, int idx, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.Get(idx);
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[0] { }, 3, "Нет элементов")]
       
        public void GetNegativeTest(int[] array, int idx, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.Get(idx));
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestCase(new int[5] { 3, 2, 3, 4, 33},new int[5] {33,4,3,2,3})]
        [TestCase(new int[5] { 5,5,5,5,5},new int[5] { 5,5,5,5,5})]
        [TestCase(new int[0] { },new int[0] { })]
        [TestCase(new int[1] { 2 },new int[1] { 2 })]
         public void Revarse(int[] array, int[] expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            
            //assert
            Assert.AreEqual(linked.Reverse(), expected);
        }



        [TestCase(new int[5] { 3, 2, 3, 4, 33}, 33)]
        [TestCase(new int[5] { 5,5,5,5,5},5)]
        [TestCase(new int[1] { 2 },2)]
         public void MaxTest(int[] array, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.Max();
            
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[0] { }, "Нет элементов")]

        public void MaxNegativeTest(int[] array,  string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.Max());
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestCase(new int[5] { 3, 2, 3, 4, 33}, 2)]
        [TestCase(new int[5] { 5,5,5,5,5},5)]
        [TestCase(new int[1] { 2 },2)]
         public void MinTest(int[] array, int expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int actual = linked.Min();
            
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[0] { }, "Нет элементов")]

        public void MinNegativeTest(int[] array, string expectedMessage)
        {
            //act
            LinkedList linked = new LinkedList(array);
            Exception ex = Assert.Throws(typeof(NullReferenceException), () => linked.Min());
            //assert
            Assert.AreEqual(ex.Message, expectedMessage);
        }


        [TestCase(new int[6] { 3, 2, 3, 4, 33,0},new int[6] { 0,2,3,3,4,33})]
        [TestCase(new int[5] { 5,5,5,5,5},new int[5] { 5, 5, 5, 5, 5 })]
        [TestCase(new int[0] { },new int[0] { })]
        [TestCase(new int[1] { 2 },new int[1] { 2 })]
         public void SortTest(int[] array, int[] expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int[] actual = linked.Sort();
            
            //assert
            Assert.AreEqual(actual, expected);
        }
        
        [TestCase(new int[5] { 3, 2, 3, 4, 33},new int[5] { 33,4,3,3,2})]
        [TestCase(new int[5] { 5,5,5,5,5},new int[5] { 5, 5, 5, 5, 5 })]
        [TestCase(new int[0] { },new int[0] { })]
        [TestCase(new int[1] { 2 },new int[1] { 2 })]
         public void SortDescTest(int[] array, int[] expected)
        {
            //act
            LinkedList linked = new LinkedList(array);
            int[] actual = linked.SortDesc();
            
            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
using Lambdanator;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        string LocalProperty { get; set; }

        class Target
        {
            public int field;
            public string Property { get; set; }
            public void Method() { }
            public object AnotherMethod() { return null; }

            public static void StaticMethod() {}
        }

        [Test]
        public void Method_test()
        {
            var member = λ.Reflect<Target>(x => x.Method());

            Assert.AreEqual("Method", member.Name);
        }

        [Test]
        public void Void_method_test()
        {
            var member = λ.Reflect<Target>(x => x.AnotherMethod());

            Assert.AreEqual("AnotherMethod", member.Name);
        }

        [Test]
        public void Local_method_test()
        {
            var member = λ.Reflect(() => Local_method_test());

            Assert.AreEqual("Local_method_test", member.Name);
        }

        [Test]
        public void Static_method_test()
        {
            var member = λ.Reflect(() => Target.StaticMethod());

            Assert.AreEqual("StaticMethod", member.Name);
        }

        [Test]
        public void Property_test()
        {
            var member = λ.Reflect<Target>(x => x.Property);

            Assert.AreEqual("Property", member.Name);
        }

        [Test]
        public void Local_property_test()
        {
            var member = λ.Reflect(() => LocalProperty);

            Assert.AreEqual("LocalProperty", member.Name);
        }

        [Test]
        public void Property_with_cast_test()
        {
            var member = λ.Reflect<Target>(x => (object)x.Property);

            Assert.AreEqual("Property", member.Name);
        }

        [Test]
        public void Field_test()
        {
            var member = λ.Reflect<Target>(x => x.field);

            Assert.AreEqual("field", member.Name);
        }

        [Test]
        public void Field_with_cast_test()
        {
            var member = λ.Reflect<Target>(x => (object)x.field);

            Assert.AreEqual("field", member.Name);
        }
    }
}

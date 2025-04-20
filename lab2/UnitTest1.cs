namespace stp_lab2.Test_stp_lab2
{
    public class Test_stp_lab2
    {
        private RGB _rgb;
        [SetUp]

        public void Setup()
        {
            _rgb = new RGB();
        }

        [Test]
        public void r_input_test()
        {
            int r = 234;

            _rgb.r=r;

            Assert.That(_rgb.r, Is.EqualTo(r));   
        }

        [Test]
        public void r_input_test_negative_value()
        {
            int r = -100;

            _rgb.r = r;

            Assert.That(_rgb.r, Is.EqualTo(0) , $"The check for setting a negative number in the r input function is not implemented");
        }

        [Test]
        public void r_input_test_overflow_of_255()
        {
            int r = 290;

            _rgb.r = r;

            Assert.That(_rgb.r, Is.EqualTo(255), $"Checking the setting of a number greater than 255 in RGB is not implemented in r input function");
        }

        [Test]
        public void test_Init_function()
        {
            int r = 234;
            int g = 120;
            int b = 34;

            _rgb.Init(r,g,b);

            Assert.That((_rgb.r, _rgb.g, _rgb.b), Is.EqualTo((r, g, b)), $"Expected : R:{r} G:{g} B:{b}, but was: R:{_rgb.r} G:{_rgb.g} B:{_rgb.b}");
        }

        [Test]
        public void test_Init_function_negative_value()
        {
            int r = -234;
            int g = -120;
            int b = -34;

            _rgb.Init(r, g, b);

            Assert.That((_rgb.r, _rgb.g, _rgb.b), Is.EqualTo((0, 0, 0)), $"Expected : R:{0} G:{0} B:{0}, but was: R:{_rgb.r} G:{_rgb.g} B:{_rgb.b}\n  The check for setting a negative number in the Init function is not implemented");
        }

        [Test]
        public void test_Init_function_overflow_of_255()
        {
            int r = 274;
            int g = 280;
            int b = 344;

            _rgb.Init(r, g, b);

            Assert.That((_rgb.r, _rgb.g, _rgb.b), Is.EqualTo((255, 255, 255)), $"Expected : R:{255} G:{255} B:{255}, but was: R:{_rgb.r} G:{_rgb.g} B:{_rgb.b}\n  Checking the setting of a number greater than 255 in RGB is not implemented in the Init function");
        }

        [Test]
        public void testing_add_function()
        {
            RGB first =new RGB(120,30,50);
            RGB second = new RGB(130, 40, 60);
            RGB expected = new RGB(250, 70, 110);

            _rgb=_rgb.Add(first,second);

            Assert.That((_rgb.r, _rgb.g, _rgb.b), Is.EqualTo((expected.r, expected.g, expected.b)), $"Expected : R:{expected.r} G:{expected.g} B:{expected.b}, but was: R:{_rgb.r} G:{_rgb.g} B:{_rgb.b}");
        }

        [Test]
        public void testing_add_function_for_overflow_of_255_1_values()
        {
            RGB first = new RGB(200, 30, 50);
            RGB second = new RGB(130, 40, 60);
            RGB expected = new RGB(255, 70, 110);

            _rgb = _rgb.Add(first, second);

            Assert.That((_rgb.r, _rgb.g, _rgb.b), Is.EqualTo((expected.r, expected.g, expected.b)), $"Expected : R:{expected.r} G:{expected.g} B:{expected.b}, but was: R:{_rgb.r} G:{_rgb.g} B:{_rgb.b}");
        }

        [Test]
        public void testing_add_function_for_overflow_of_255_2_values()
        {
            RGB first = new RGB(200, 230, 50);
            RGB second = new RGB(130, 240, 60);
            RGB expected = new RGB(255, 255, 110);

            _rgb = _rgb.Add(first, second);

            Assert.That((_rgb.r, _rgb.g, _rgb.b), Is.EqualTo((expected.r, expected.g, expected.b)), $"Expected : R:{expected.r} G:{expected.g} B:{expected.b}, but was: R:{_rgb.r} G:{_rgb.g} B:{_rgb.b}");
        }

        [Test]
        public void testing_add_function_for_overflow_of_255_3_values()
        {
            RGB first = new RGB(200, 230, 250);
            RGB second = new RGB(130, 240, 60);
            RGB expected = new RGB(255, 255, 255);

            _rgb = _rgb.Add(first, second);

            Assert.That((_rgb.r, _rgb.g, _rgb.b), Is.EqualTo((expected.r, expected.g, expected.b)), $"Expected : R:{expected.r} G:{expected.g} B:{expected.b}, but was: R:{_rgb.r} G:{_rgb.g} B:{_rgb.b}");
        }

        [Test]
        public void testing_white_black_point_function()
        {
            _rgb.Init(200, 230, 250);
            double expected = 0.3 * 200 + 0.59 * 230 + 0.11 * 250;

            double white_black_point = _rgb.white_black_point();

            Assert.That(white_black_point, Is.EqualTo(expected), $"R:{_rgb.r} G:{_rgb.g} B:{_rgb.b}\n  Сalculation error");
        }
    }
}

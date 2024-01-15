namespace Television.Tests
{
    using NUnit.Framework;
    using System;
    public class TelevisionDeviceTests
    {


        [Test]
        public void TelevisionDeviceShouldInitializeCorrectly()
        {
            //Arrange
            string brand = "Sony";
            double price = 899.99;
            int screenWidth = 1920;
            int screenHeigth = 1080;

            //Act
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            //Assert
            Assert.IsNotNull(tv);
            Assert.AreEqual(brand, tv.Brand);
            Assert.AreEqual(price, tv.Price);
            Assert.AreEqual(screenWidth, tv.ScreenWidth);
            Assert.AreEqual(screenHeigth, tv.ScreenHeigth);
        }

        [Test]
        public void SwithOnReturnsCorrectInformation()
        {
            //Arrange
            TelevisionDevice tv = new TelevisionDevice("Sony", 899.99, 1920, 1080);
            string expectedOutput = "Cahnnel 0 - Volume 13 - Sound On";

            //Act
            var output = tv.SwitchOn();

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void SwitchOnLastMutedReturnsCorrectInformation()
        {
            //Arrange
            TelevisionDevice tv = new TelevisionDevice("Sony", 899.99, 1920, 1080);

            tv.MuteDevice();
            string expectedOutput = "Cahnnel 0 - Volume 13 - Sound Off";

            //Act
            string output = tv.SwitchOn();

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void ChangeChannelNegativeThrowsException()
        {
            //Arrange
            TelevisionDevice tv = new TelevisionDevice("Sony", 899.99, 1920, 1080);


            //Act & Assert
            Assert.Throws<ArgumentException>(() => tv.ChangeChannel(-1));
        }

        [Test]
        public void ChangeChannelPositiveReturnsValidArgument()
        {
            //Arrange
            TelevisionDevice tv = new TelevisionDevice("Sony", 899.99, 1920, 1080);
            int newChannel = 5;

            //Act
            int channel = tv.ChangeChannel(newChannel);

            //Assert
            Assert.AreEqual(newChannel, channel);
        }

        [Test]
        public void VolumeUpShouldChangeCorrectly()
        {
            //Arrange
            TelevisionDevice tv = new TelevisionDevice("Sony", 899.99, 1920, 1080);

            string expectedOutput = "Volume: 100";

            //Act
            string output = tv.VolumeChange("UP", 100);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void VolumeDownShouldChangeCorrectly()
        {
            //Arrange
            TelevisionDevice tv = new TelevisionDevice("Sony", 899.99, 1920, 1080);

            string expectedOutput = "Volume: 3";

            //Act
            string output = tv.VolumeChange("DOWN", 10);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void VolumeDownLessThanZero()
        {
            //Arrange
            TelevisionDevice tv = new TelevisionDevice("Sony", 899.99, 1920, 1080);

            string expectedOutput = "Volume: 0";

            //Act
            string output = tv.VolumeChange("DOWN", 14);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void IsUnmutedShouldWorkCorrectly()
        {
            //Arrange
            TelevisionDevice tv = new TelevisionDevice("Sony", 899.99, 1920, 1080);
            tv.MuteDevice(); //Mute first

            //Act
            bool isMuted = tv.MuteDevice(); //Unmute 

            //Assert
            Assert.IsFalse(isMuted);
        }

        [Test]
        public void IsMutedShouldWorkCorrectly()
        {
            //Arrange
            TelevisionDevice tv = new TelevisionDevice("Sony", 899.99, 1920, 1080);

            //Act
            bool isMuted = tv.MuteDevice(); //Mute 

            //Assert
            Assert.IsTrue(isMuted);
        }

        [Test]
        public void ToStringMethodReturnsCorrectOutput()
        {
            //Arrange
            TelevisionDevice tv = new TelevisionDevice("Sony", 899.99, 1920, 1080);
            string expectedOutput = "TV Device: Sony, Screen Resolution: 1920x1080, Price 899.99$";

            //Act
            string output = tv.ToString();

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
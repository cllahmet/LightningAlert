using LightningAlert.Model;
using LightningAlert.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LightningAlert.UnitTests.Validators
{
    public class LightningStrikeValidatorTest
    {
        [Fact]
        public void Return_True_If_Data_Valid()
        {
            LightningStrikeValidator validator = new LightningStrikeValidator();
            LightningStrike lightningStrike = new LightningStrike()
            {
                flashType = 1,
                strikeTime = 1446760902712,
                latitude = 40.6361602,
                longitude = -94.4143559,
                peakAmps = -5516,
                reserved = "000",
                icHeight = 18589,
                receivedTime = 1446760915182,
                numberOfSensors = 19,
                multiplicity = 8
            };

            var result = validator.Validate(lightningStrike);

            Assert.True(result.IsValid);
        }
        [Fact]
        public void Return_False_If_Latitude_Is_Empty()
        {
            LightningStrikeValidator validator = new LightningStrikeValidator();
            LightningStrike lightningStrike = new LightningStrike()
            {
                flashType = 1,
                strikeTime = 1446760902712,
                longitude = -94.4143559,
                peakAmps = -5516,
                reserved = "000",
                icHeight = 18589,
                receivedTime = 1446760915182,
                numberOfSensors = 19,
                multiplicity = 8
            };

            var result = validator.Validate(lightningStrike);

            Assert.False(result.IsValid);
        }
        [Fact]
        public void Return_False_If_Longitude_Invalid()
        {
            LightningStrikeValidator validator = new LightningStrikeValidator();
            LightningStrike lightningStrike = new LightningStrike()
            {
                flashType = 1,
                strikeTime = 1446760902712,
                latitude = 40.6361602,
                longitude = 350,
                peakAmps = -5516,
                reserved = "000",
                icHeight = 18589,
                receivedTime = 1446760915182,
                numberOfSensors = 19,
                multiplicity = 8
            };

            var result = validator.Validate(lightningStrike);

            Assert.False(result.IsValid);
        }
        [Fact]
        public void Return_False_If_Flash_Type_Undefined()
        {
            LightningStrikeValidator validator = new LightningStrikeValidator();
            LightningStrike lightningStrike = new LightningStrike()
            {
                flashType = 5,
                strikeTime = 1446760902712,
                latitude = 40.6361602,
                longitude = -94.4143559,
                peakAmps = -5516,
                reserved = "000",
                icHeight = 18589,
                receivedTime = 1446760915182,
                numberOfSensors = 19,
                multiplicity = 8
            };

            var result = validator.Validate(lightningStrike);

            Assert.False(result.IsValid);
        }
    }
}

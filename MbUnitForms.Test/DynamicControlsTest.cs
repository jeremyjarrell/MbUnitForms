#region Copyright (c) 2003-2005, Luke T. Maxon

/********************************************************************************************************************
'
' Copyright (c) 2003-2005, Luke T. Maxon
' All rights reserved.
' 
' Redistribution and use in source and binary forms, with or without modification, are permitted provided
' that the following conditions are met:
' 
' * Redistributions of source code must retain the above copyright notice, this list of conditions and the
' 	following disclaimer.
' 
' * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and
' 	the following disclaimer in the documentation and/or other materials provided with the distribution.
' 
' * Neither the name of the author nor the names of its contributors may be used to endorse or 
' 	promote products derived from this software without specific prior written permission.
' 
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
' WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
' PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
' ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
' LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
' INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
' OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN
' IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
'
'*******************************************************************************************************************/

#endregion

using MbUnit.Framework;

namespace MbUnit.Extensions.Forms.TestApplications
{
    [TestFixture]
    public class DynamicControlsTest : MbUnitFormTest
    {
        public override void Setup()
        {
            new DynamicControlsTestForm().Show();
        }

        [Test]
        public void DynamicButtonClick()
        {
            ButtonTester addButton = new ButtonTester("addButton");
            addButton.Click();
            ButtonTester dynamicButton = new ButtonTester("button0");
            dynamicButton.Click();
            Assert.AreEqual("1", dynamicButton.Text);
        }

        [Test]
        [ExpectedException(typeof(AmbiguousNameException))]
        public void DynamicControlsWithDuplicateNameIsAmbiguous()
        {
            ButtonTester addDuplicateButton = new ButtonTester("btnAddDuplicate");
            ButtonTester duplicate = new ButtonTester("duplicate");

            addDuplicateButton.Click();
            addDuplicateButton.Click();

            duplicate.Click();
        }

        [Test]
        public void DynamicControlsWithDuplicateNameCount()
        {
            ButtonTester addDuplicateButton = new ButtonTester("btnAddDuplicate");
            ButtonTester duplicate = new ButtonTester("duplicate");

            addDuplicateButton.Click();
            addDuplicateButton.Click();
            addDuplicateButton.Click();

            Assert.AreEqual(3, duplicate.Count);
        }

        [Test]
        public void DynamicControlsWithDuplicateNameEnumerator()
        {
            ButtonTester addDuplicateButton = new ButtonTester("btnAddDuplicate");
            ButtonTester duplicate = new ButtonTester("duplicate");

            addDuplicateButton.Click();
            addDuplicateButton.Click();
            addDuplicateButton.Click();

            foreach(ButtonTester button in duplicate)
            {
                button.Click();
            }

            foreach(ButtonTester button in duplicate)
            {
                Assert.AreEqual("1", button.Text);
            }
        }

        [Test]
        public void DynamicControlsWithDuplicateNameWorksByIndex()
        {
            ButtonTester addDuplicateButton = new ButtonTester("btnAddDuplicate");
            ButtonTester duplicate = new ButtonTester("duplicate");

            addDuplicateButton.Click();
            addDuplicateButton.Click();

            duplicate[0].Click();
            duplicate[1].Click();
        }

        [Test]
        [ExpectedException(typeof(NoSuchControlException), "duplicate[2]")]
        public void DynamicControlsWithDuplicateNameNotFound()
        {
            ButtonTester addDuplicateButton = new ButtonTester("btnAddDuplicate");
            ButtonTester duplicate = new ButtonTester("duplicate");

            addDuplicateButton.Click();
            addDuplicateButton.Click();

            duplicate[0].Click();
            duplicate[1].Click();
            duplicate[2].Click();
        }
    }
}
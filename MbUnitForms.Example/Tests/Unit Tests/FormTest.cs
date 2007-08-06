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

using MbUnit.Extensions.Forms;
using MbUnit.Extensions.Forms.ExampleApplication;
using MbUnit.Framework;
using Rhino.Mocks;


namespace MbUnit.Forms.ExampleApplication
{
    [TestFixture]
    public class FormTest : MbUnitFormTest
    {
        private MockRepository mockRepository;
        private IAppController controller;
        private AlternateAppForm alternateAppForm;

        const string TestValue = "TestValue";
        const string UpdatedValue = "UpdatedValue";

        public override void Setup()
        {
            mockRepository = new MockRepository();
        }

        public override void TearDown()
        {
            mockRepository.VerifyAll();
            base.TearDown();
        }

        [Test]
        public void ButtonLabelShouldBeControllerValue()
        {
            controller = mockRepository.DynamicMock<IAppController>();

            using (mockRepository.Record())
            {
                Expect.
                    On(controller).
                    Call(controller.GetData()).
                    Return(UpdatedValue);
            }
            using (mockRepository.Playback())
            {
                alternateAppForm = new AlternateAppForm(controller);
                alternateAppForm.Show();

                ButtonTester button = new ButtonTester("countButton");
                button["Text"] = TestValue;

                Assert.AreEqual(TestValue, button.Text);
            }
        }

        [Test]
        public void CountButtonShouldInvokeControllerCount()
        {
            controller = mockRepository.DynamicMock<IAppController>();

            using (mockRepository.Record())
            {
                Expect.
                    On(controller).
                    Call(controller.GetData()).
                    Return(TestValue).
                    Repeat.Twice();

                controller.Count();
                LastCall.Repeat.Once();
            }
            using (mockRepository.Playback())
            {
                alternateAppForm = new AlternateAppForm(controller);
                alternateAppForm.Show();

                ButtonTester button = new ButtonTester("countButton");
                button.Click();
            }
        }

        [Test]
        public void ShowModalButtonShouldInvokeControllerShowModal()
        {
            controller = mockRepository.DynamicMock<IAppController>();
            using (mockRepository.Record())
            {
                Expect.
                    On(controller).
                    Call(controller.GetData()).
                    Return(TestValue);
            }
            using (mockRepository.Playback())
            {
                alternateAppForm = new AlternateAppForm(controller);
                alternateAppForm.Show();

                ButtonTester button = new ButtonTester("showModalButton");
                button.Click();
            }
        }

        [Test]
        public void ButtonLabelShouldUpdateAfterClick()
        {
            controller = mockRepository.DynamicMock<IAppController>();

            using (mockRepository.Record())
            {
                Expect.
                    On(controller).
                    Call(controller.GetData()).
                    Return(UpdatedValue).
                    Repeat.Twice();
            }
            using (mockRepository.Playback())
            {
                alternateAppForm = new AlternateAppForm(controller);
                alternateAppForm.Show();

                ButtonTester button = new ButtonTester("countButton");
                button.Click();

                LabelTester countLabel = new LabelTester("countLabel");
                Assert.AreEqual(UpdatedValue, countLabel.Text);
            }
        }
    }
}
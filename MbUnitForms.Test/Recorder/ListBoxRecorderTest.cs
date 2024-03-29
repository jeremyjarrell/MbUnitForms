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

using System;
using MbUnit.Extensions.Forms.TestApplications;
using MbUnit.Framework;
using System.Windows.Forms;

namespace MbUnit.Extensions.Forms.Recorder.Test
{
    [TestFixture]
    [FixtureCategory("Recorder")]
    public class ListBoxRecorderTest : MbUnitFormTest
    {
        [Test]
        public void SelectItem()
        {
            Form form = new ListBoxTestForm();
            form.Show();
            TestWriter writer = new TestWriter(form);
            Assert.AreEqual("", writer.Test);

            ListBoxTester myListBox = new ListBoxTester("myListBox", form);

            myListBox.Select(0);

            Assert.AreEqual(
                    @"[Test]
public void Test()
{

	ListBoxTester myListBox = new ListBoxTester(""myListBox"");

	myListBox.ClearSelected();
	myListBox.SetSelected(0, True); //Red

}",
                    writer.Test);
        }

        [Test]
        public void MutlipleSelection()
        {
            Form form = new ListBoxTestForm();
            form.Show();
            TestWriter writer = new TestWriter(form);
            Assert.AreEqual("", writer.Test);

            ListBoxTester myListBox = new ListBoxTester("myListBox", form);

            myListBox.ClearSelected();
            myListBox.SetSelected(0, true); //Red
            myListBox.SetSelected(2, true); //Yellow
            myListBox.SetSelected(4, true); //Blue
            myListBox.SetSelected(6, true); //Violet

            Assert.AreEqual(
                    @"[Test]
public void Test()
{

	ListBoxTester myListBox = new ListBoxTester(""myListBox"");

	myListBox.ClearSelected();
	myListBox.SetSelected(0, True); //Red
	myListBox.ClearSelected();
	myListBox.SetSelected(0, True); //Red
	myListBox.SetSelected(2, True); //Yellow
	myListBox.ClearSelected();
	myListBox.SetSelected(0, True); //Red
	myListBox.SetSelected(2, True); //Yellow
	myListBox.SetSelected(4, True); //Blue
	myListBox.ClearSelected();
	myListBox.SetSelected(0, True); //Red
	myListBox.SetSelected(2, True); //Yellow
	myListBox.SetSelected(4, True); //Blue
	myListBox.SetSelected(6, True); //Violet

}",
                    writer.Test);
        }

        [Test]
        public void SingleSelectBox()
        {
            Form form = new ListBoxTestForm();
            form.Show();
            TestWriter writer = new TestWriter(form);
            Assert.AreEqual("", writer.Test);

            ListBoxTester myListBox = new ListBoxTester("mySingleSelectBox", form);

            myListBox.ClearSelected();
            myListBox.SetSelected(0, true); //Red
            myListBox.SetSelected(2, true); //Yellow
            myListBox.SetSelected(4, true); //Blue
            myListBox.SetSelected(6, true); //Violet

            Assert.AreEqual(
                    @"[Test]
public void Test()
{

	ListBoxTester mySingleSelectBox = new ListBoxTester(""mySingleSelectBox"");

	mySingleSelectBox.Select(0); //Can
	mySingleSelectBox.Select(2); //Select
	mySingleSelectBox.Select(4); //At
	mySingleSelectBox.Select(6); //Time

}",
                    writer.Test);
        }
    }
}
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
using System.Windows.Forms;
using MbUnit.Extensions.Forms.TestApplications;
using MbUnit.Framework;

namespace MbUnit.Extensions.Forms.Recorder.Test
{
    [TestFixture]
    [FixtureCategory("Recorder")]
    public class ComboBoxRecorderTest : MbUnitFormTest
    {
        [Test]
        public void ComboBoxEnter()
        {
			Form f = new ComboBoxTestForm();
			f.Show();

            TestWriter writer = new TestWriter(f);
            Assert.AreEqual("", writer.Test);

            ComboBoxTester comboBox = new ComboBoxTester("myComboBox");
            //doing 2 of these tests the collapsing processor.
            comboBox.Enter("abc");
            comboBox.Enter("abcd");

            Assert.AreEqual(
                    @"[Test]
public void Test()
{

	ComboBoxTester myComboBox = new ComboBoxTester(""myComboBox"");

	myComboBox.Enter(""abcd"");

}",
                    writer.Test);
        }

        [Test]
        public void ComboBoxSelect()
        {
			Form f = new ComboBoxTestForm();
			f.Show();

			TestWriter writer = new TestWriter(f);
			Assert.AreEqual("", writer.Test);

            ComboBoxTester comboBox = new ComboBoxTester("myComboBox");
            //doing 2 of these tests the collapsing processor.
            comboBox.Select(1);
            comboBox.Select(2);

            Assert.AreEqual(
                    @"[Test]
public void Test()
{

	ComboBoxTester myComboBox = new ComboBoxTester(""myComboBox"");

	myComboBox.Select(1); //two
	myComboBox.Select(2); //three

}",
                    writer.Test);
        }

        [Test]
        public void ComboBoxEnterAndSelect()
        {
			Form f = new ComboBoxTestForm();
			f.Show();

			TestWriter writer = new TestWriter(f);
			Assert.AreEqual("", writer.Test);

            ComboBoxTester comboBox = new ComboBoxTester("myComboBox");
            //doing 2 of these tests the collapsing processor.
            comboBox.Select(1);
            comboBox.Enter("abcd");
            comboBox.Enter("abcde");
            comboBox.Select(2);

            Assert.AreEqual(
                    @"[Test]
public void Test()
{

	ComboBoxTester myComboBox = new ComboBoxTester(""myComboBox"");

	myComboBox.Select(1); //two
	myComboBox.Enter(""abcde"");
	myComboBox.Select(2); //three

}",
                    writer.Test);
        }
    }
}
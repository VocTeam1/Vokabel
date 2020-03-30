using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vokabel
{
    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void Dictionary_GetNext_Returns_CurrentQuestion()
        {
            //Arrange
           Dictionary dictionary = new Dictionary();

            //Act
            CurrentQuestion currentQuestion = new CurrentQuestion();
            currentQuestion = dictionary.GetNext();
            //Assert
            Assert.IsNotNull(currentQuestion.answers);
        }
        [TestMethod]
        public void Dictionary_IsCorrectAnswer_Returns_True()
        {
            //Arrange
            Dictionary dictionary = new Dictionary();

            //Act
            CurrentQuestion currentQuestion = new CurrentQuestion();
            currentQuestion = dictionary.GetNext();
            //Assert
            Assert.IsTrue(dictionary.IsCorrectAnswer( currentQuestion.question, currentQuestion.answers[currentQuestion.correctID]));
        }
        [TestMethod]
        public void Dictionary_IsCorrectAnswer_Returns_False()
        {
            //Arrange
            Dictionary dictionary = new Dictionary();

            //Act
            CurrentQuestion currentQuestion = new CurrentQuestion();
            currentQuestion = dictionary.GetNext();
            //Assert
            Assert.IsTrue(dictionary.IsCorrectAnswer(currentQuestion.question, currentQuestion.answers[0]));
        }
    }
}

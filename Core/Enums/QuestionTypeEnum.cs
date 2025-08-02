using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum QuestionTypeEnum
    {
        SingleChoice = 1,
        MultipleChoice,
        Dropdown,
        TextBox,
        TextArea,
        Number,
        Date

    }
}

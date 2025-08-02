using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedQuestionAndAttachmentLabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "AttachmentLabel",
                value: "ارفاق الدليل");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "المنهجية المستخدمة في تنفيذ الاستراتيجية مع الأدلة على تفعليها");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "قائمة تحديد الأولويات الاستراتيجية والاحتياجات المطلوبة لمرحلة التنفيذ");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "قائمة الأهداف المرتبطة مع الاستراتيجية ومؤشرات الأداء الخاصة بالإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "التقارير الدورية لمتابعة تنفيذ الخطة وفقاً لمؤشرات الإدارة التشغيلية");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "محاضر اجتماعات لمناقشة تقارير الأداء مع الإجراءات التصحيحية المتخذة في عملية القياس");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "أمثلة تعكس وجود بيئة تحفيزية لتعزيز القيم");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: "تقديم وتوضيح أمثلة للمبادرات والبرامج التي تعمل على تعزيز القيم");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "تقارير مشاركة العاملين في برامج التدريب والتطوير المهني");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Title",
                value: "أدلة على تنفيذ برامج لتبادل المعرفة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Title",
                value: "سجل المخاطر الخاص بالإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Title",
                value: "قائمة الإجراءات والسياسات واللوائح والنماذج والأدلة ذات الصلة بأعمال الإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Title",
                value: "مصفوفة الصلاحيات والمسؤوليات المعتمدة للإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Title",
                value: "نماذج لتنفيذ الأعمال والأنشطة وفقا للإجراءات والمنهجيات المعتمدة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Title",
                value: "قائمة المتطلبات القانونية والتشريعية ذات الصلة بالإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Title",
                value: "أدلة على رصد التغييرات وآليات المواءمة معها");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Title",
                value: "إطار فهم أصحاب المصلحة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Title",
                value: "أمثلة على تحديث الإطار بشكل دوري");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Title",
                value: "الشراكات والمبادرات التي تم تنفيذها، وأثرها الإيجابي على الهيئة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Title",
                value: "خطط التحسين والتطوير للمبادرات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Title",
                value: "تفعيل الشراكات والاتفاقيات الإستراتيجية وفقاً لبنود الشراكة ذات المنفعة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Title",
                value: "الخطة السنوية لتحسين الإجراءات والعمليات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 22,
                column: "Title",
                value: "قائمة التحسينات التي تم تنفيذها  على الخدمات والإجراءات وأثر ذلك على العمل");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 23,
                column: "Title",
                value: "شواهد للمقترحات والأفكار الإبداعية المقدمة من قبل المعنيين");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 24,
                column: "Title",
                value: "عينة لاستطلاع آراء المستفيدين وأخذ المقترحات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 25,
                column: "Title",
                value: "نماذج للقاءات والفعاليات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 26,
                column: "Title",
                value: " قائمة المستفيدين وتصنيفاتهم");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 27,
                column: "Title",
                value: "قائمة احتياجات وتوقعات المستفيدين");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 28,
                column: "Title",
                value: "أدلة على القيام بأخذ التغذية الراجعة عن طريق مجموعات التركيز، المسوحات واستطلاعات الرأي، العاملين المباشرين في التعامل مع المستفيدين أو أي أساليب أخرى");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 29,
                column: "Title",
                value: "نماذج للشكاوى وطرق معالجتها");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 30,
                column: "Title",
                value: " دراسة توضح رحلة العميل ونقاط التحسين التي تم حصرها والتحسين الذي تم تنفيذه أو خطط له بناء على هذه الدراسة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 31,
                column: "Title",
                value: "تفعيل الموقع الإلكتروني للتعريف بالإدارة والخدمات التي تقدمها، والمهام والسياسات والوحدات التابعة لها (مع إدراج رابط صفحة الإدارة بالموقع الإلكتروني)");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 32,
                column: "Title",
                value: " قائمة الخدمات على أن تشمل (اسم الخدمة، تعريف الخدمة، قنوات تقديم الخدمة، الجهة المستفيدة، الفئة المستهدفة، مدة تنفيذ الخدمة)");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 33,
                column: "Title",
                value: "  فعاليات وأدوات التوعية والتعريف بالخدمات والمنتجات المقدمة للمستفيدين");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 34,
                column: "Title",
                value: "محضر أو تقرير يوضح مخرجات تنفيذ الأساليب والإجراءات لتحديد مجالات الابداع والابتكار");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 35,
                column: "Title",
                value: "وجود قائمة بمجالات الإبداع والتحسين المستهدفة لتحقيق أهداف الإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 36,
                column: "Title",
                value: "دليل على وجود قنوات ووسائل تمكن من استقبال الأفكار والابتكارات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 37,
                column: "Title",
                value: "أدلة توضح تطبيق منهجيات وأساليب تحفيز تقديم الأفكار الابداعية");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 38,
                column: "Title",
                value: "قائمة الأفكار الإبداعية والابتكارات المرصودة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 39,
                column: "Title",
                value: "نماذج لأفكار وحلول تم تبنيها ورعايتها بواسطة الإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 40,
                column: "Title",
                value: "دليل على توعية وتهيئة العاملين للتغيير والتحول");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 41,
                column: "Title",
                value: "نماذج للبحوث التي تم دعمها");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 42,
                column: "Title",
                value: "نماذج للبحوث والدراسات المخطط تنفيذها");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 43,
                column: "Title",
                value: "قائمة البحوث الموجودة بالإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 44,
                column: "Title",
                value: "تقديم أدلة على توظيف وتفعيل الأنظمة والتقنيات الحديثة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 45,
                column: "Title",
                value: "قائمة الإجراءات المؤتمتة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 46,
                column: "Title",
                value: "قائمة البرامج والدورات التدريبية المقدمة للعاملين في مجال إدارة وتطوير العمليات واستخدام التقنيات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 47,
                column: "Title",
                value: "صور الأنظمة التقنية المستخدمة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 48,
                column: "Title",
                value: "نماذج توضح قيام الإدارة بجمع وتصنيف البيانات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 49,
                column: "Title",
                value: "دليل يوضح آلية الأرشفة وحفظ واستدعاء المعلومات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 50,
                column: "Title",
                value: "نماذج لتقارير تحليل البيانات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 51,
                column: "Title",
                value: "أدلة على تنفيذ منهجيات لتبادل المعارف والخبرات بين العاملين");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "AttachmentLabel",
                value: "* ارفاق الدليل");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "* المنهجية المستخدمة في تنفيذ الاستراتيجية مع الأدلة على تفعليها");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "* قائمة تحديد الأولويات الاستراتيجية والاحتياجات المطلوبة لمرحلة التنفيذ");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "* قائمة الأهداف المرتبطة مع الاستراتيجية ومؤشرات الأداء الخاصة بالإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "* التقارير الدورية لمتابعة تنفيذ الخطة وفقاً لمؤشرات الإدارة التشغيلية");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "* محاضر اجتماعات لمناقشة تقارير الأداء مع الإجراءات التصحيحية المتخذة في عملية القياس");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "* أمثلة تعكس وجود بيئة تحفيزية لتعزيز القيم");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: "* تقديم وتوضيح أمثلة للمبادرات والبرامج التي تعمل على تعزيز القيم");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "* تقارير مشاركة العاملين في برامج التدريب والتطوير المهني");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Title",
                value: "* أدلة على تنفيذ برامج لتبادل المعرفة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Title",
                value: "* سجل المخاطر الخاص بالإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Title",
                value: "* قائمة الإجراءات والسياسات واللوائح والنماذج والأدلة ذات الصلة بأعمال الإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Title",
                value: "* مصفوفة الصلاحيات والمسؤوليات المعتمدة للإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Title",
                value: "* نماذج لتنفيذ الأعمال والأنشطة وفقا للإجراءات والمنهجيات المعتمدة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Title",
                value: "* قائمة المتطلبات القانونية والتشريعية ذات الصلة بالإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Title",
                value: "* أدلة على رصد التغييرات وآليات المواءمة معها");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Title",
                value: "* إطار فهم أصحاب المصلحة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Title",
                value: "* أمثلة على تحديث الإطار بشكل دوري");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Title",
                value: "* الشراكات والمبادرات التي تم تنفيذها، وأثرها الإيجابي على الهيئة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Title",
                value: "* خطط التحسين والتطوير للمبادرات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Title",
                value: "* تفعيل الشراكات والاتفاقيات الإستراتيجية وفقاً لبنود الشراكة ذات المنفعة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Title",
                value: "* الخطة السنوية لتحسين الإجراءات والعمليات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 22,
                column: "Title",
                value: "* قائمة التحسينات التي تم تنفيذها  على الخدمات والإجراءات وأثر ذلك على العمل");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 23,
                column: "Title",
                value: "* شواهد للمقترحات والأفكار الإبداعية المقدمة من قبل المعنيين");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 24,
                column: "Title",
                value: "* عينة لاستطلاع آراء المستفيدين وأخذ المقترحات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 25,
                column: "Title",
                value: "* نماذج للقاءات والفعاليات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 26,
                column: "Title",
                value: "*  قائمة المستفيدين وتصنيفاتهم");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 27,
                column: "Title",
                value: "* قائمة احتياجات وتوقعات المستفيدين");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 28,
                column: "Title",
                value: "* أدلة على القيام بأخذ التغذية الراجعة عن طريق مجموعات التركيز، المسوحات واستطلاعات الرأي، العاملين المباشرين في التعامل مع المستفيدين أو أي أساليب أخرى");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 29,
                column: "Title",
                value: "* نماذج للشكاوى وطرق معالجتها");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 30,
                column: "Title",
                value: "*  دراسة توضح رحلة العميل ونقاط التحسين التي تم حصرها والتحسين الذي تم تنفيذه أو خطط له بناء على هذه الدراسة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 31,
                column: "Title",
                value: "* تفعيل الموقع الإلكتروني للتعريف بالإدارة والخدمات التي تقدمها، والمهام والسياسات والوحدات التابعة لها (مع إدراج رابط صفحة الإدارة بالموقع الإلكتروني)");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 32,
                column: "Title",
                value: "*  قائمة الخدمات على أن تشمل (اسم الخدمة، تعريف الخدمة، قنوات تقديم الخدمة، الجهة المستفيدة، الفئة المستهدفة، مدة تنفيذ الخدمة)");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 33,
                column: "Title",
                value: "*   فعاليات وأدوات التوعية والتعريف بالخدمات والمنتجات المقدمة للمستفيدين");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 34,
                column: "Title",
                value: "* محضر أو تقرير يوضح مخرجات تنفيذ الأساليب والإجراءات لتحديد مجالات الابداع والابتكار");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 35,
                column: "Title",
                value: "* وجود قائمة بمجالات الإبداع والتحسين المستهدفة لتحقيق أهداف الإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 36,
                column: "Title",
                value: "* دليل على وجود قنوات ووسائل تمكن من استقبال الأفكار والابتكارات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 37,
                column: "Title",
                value: "* أدلة توضح تطبيق منهجيات وأساليب تحفيز تقديم الأفكار الابداعية");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 38,
                column: "Title",
                value: "* قائمة الأفكار الإبداعية والابتكارات المرصودة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 39,
                column: "Title",
                value: "* نماذج لأفكار وحلول تم تبنيها ورعايتها بواسطة الإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 40,
                column: "Title",
                value: "* دليل على توعية وتهيئة العاملين للتغيير والتحول");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 41,
                column: "Title",
                value: "* نماذج للبحوث التي تم دعمها");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 42,
                column: "Title",
                value: "* نماذج للبحوث والدراسات المخطط تنفيذها");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 43,
                column: "Title",
                value: "* قائمة البحوث الموجودة بالإدارة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 44,
                column: "Title",
                value: "* تقديم أدلة على توظيف وتفعيل الأنظمة والتقنيات الحديثة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 45,
                column: "Title",
                value: "* قائمة الإجراءات المؤتمتة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 46,
                column: "Title",
                value: "* قائمة البرامج والدورات التدريبية المقدمة للعاملين في مجال إدارة وتطوير العمليات واستخدام التقنيات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 47,
                column: "Title",
                value: "* صور الأنظمة التقنية المستخدمة");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 48,
                column: "Title",
                value: "* نماذج توضح قيام الإدارة بجمع وتصنيف البيانات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 49,
                column: "Title",
                value: "* دليل يوضح آلية الأرشفة وحفظ واستدعاء المعلومات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 50,
                column: "Title",
                value: "* نماذج لتقارير تحليل البيانات");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 51,
                column: "Title",
                value: "* أدلة على تنفيذ منهجيات لتبادل المعارف والخبرات بين العاملين");
        }
    }
}

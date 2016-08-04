/* STUDENTS IGNORE THIS FUNCTION
 * All this does is create an initial
 * attendance record if one is not found
 * within localStorage.
 */


$(function () {

    var attendanceModel = (function () {

        var students = ["Slappy the Frog", "Lilly the Lizard", "Paulrus the Walrus",
            "Gregory the Goat", "Adam the Anaconda"];

        function getRandom() {
            return (Math.random() >= 0.5);
        }

        function getAttendance() {
            var attendance = {};
            for (var x = 0; x < students.length; x++) {
                attendance[students[x]] = [];

                for (var i = 0; i <= 11; i++) {
                    attendance[students[x]].push(getRandom());
                }
            }

            return attendance;
        }

        return {
            getAttendance: getAttendance
        }
    })();

    var attendanceView = (function() {
        
        function init() {
            var attendance = octopus.getAttendance();
            // get the 11 somehow
            var $row = $('<tr></tr>');
            $('#resultTable').find('thead').append($row);
            $row.append($('<th class="name-col">Student Name</th>'));

            for (var i = 0; i < 12; i++) {
                $row.append($('<th>').text(i+1));
            }

            $row.append($('<th class="missed-col">Days Missed-col</th>'));

            var $tbody = $('#resultTable').find('tbody');
           
            for (var studentName in attendance) {
                $row = $('<tr>').addClass('student');
                $tbody.append($row);
                $row.append($('<th>').addClass('name-col').text(studentName));
                var attendanceArray = attendance[studentName];
                for (var x1 = 0; x1 < attendanceArray.length; x1++) {
                    $row.append($('<th>').addClass('attend-col').append($('<input type="checkbox">')));
                }
            }

            

        }

        function render() {
            
        }

        return {
            init: init,
            render: render
        }

    })();


    var octopus = (function() {

        function init() {
            if (!localStorage.attendance) {
                console.log('Creating attendance records...');
                var attendance = attendanceModel.getAttendance();
                localStorage.attendance = JSON.stringify(attendance);
            }
            var r = attendanceModel.getAttendance();
            console.log(r);

            attendanceView.init();
        }

        function getAttendance() {
            return JSON.parse(localStorage.attendance);
        }

        return {
            init: init,
            getAttendance: getAttendance
        }

    })();


    //octopus.init();


}());



 (function() {
    if (!localStorage.attendance) {
        console.log('Creating attendance records...');
        function getRandom() {
            return (Math.random() >= 0.5);
        }

        var nameColumns = $('tbody .name-col'),
            attendance = {};

        nameColumns.each(function() {
            var name = this.innerText;
            attendance[name] = [];

            for (var i = 0; i <= 11; i++) {
                attendance[name].push(getRandom());
            }
        });

        localStorage.attendance = JSON.stringify(attendance);
    }
}());
 



/* STUDENT APPLICATION */
$(function() {
    var attendance = JSON.parse(localStorage.attendance),
        $allMissed = $('tbody .missed-col'),
        $allCheckboxes = $('tbody input');

    // Count a student's missed days
    function countMissing() {
        $allMissed.each(function() {
            var studentRow = $(this).parent('tr'),
                dayChecks = $(studentRow).children('td').children('input'),
                numMissed = 0;

            dayChecks.each(function() {
                if (!$(this).prop('checked')) {
                    numMissed++;
                }
            });

            $(this).text(numMissed);
        });
    }

    // Check boxes, based on attendace records
    $.each(attendance, function(name, days) {
        var studentRow = $('tbody .name-col:contains("' + name + '")').parent('tr'),
            dayChecks = $(studentRow).children('.attend-col').children('input');

        dayChecks.each(function(i) {
            $(this).prop('checked', days[i]);
        });
    });

    // When a checkbox is clicked, update localStorage
    $allCheckboxes.on('click', function() {
        var studentRows = $('tbody .student'),
            newAttendance = {};

        studentRows.each(function() {
            var name = $(this).children('.name-col').text(),
                $allCheckboxes = $(this).children('td').children('input');

            newAttendance[name] = [];

            $allCheckboxes.each(function() {
                newAttendance[name].push($(this).prop('checked'));
            });
        });

        countMissing();
        localStorage.attendance = JSON.stringify(newAttendance);
    });

    countMissing();
}());

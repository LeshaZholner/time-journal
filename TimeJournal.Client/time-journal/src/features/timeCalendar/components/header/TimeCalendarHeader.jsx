import { TimeCalendarHeaderCell } from '../cell';
import {
  TimeCalendarLeftPart,
  TimeCalendarRightPart,
  TimeCalendarRow
} from '../containers';
import './styles.scss';

const TimeCalendarHeader = ({ userCalendar }) => {
  return (
    <div className='time-calendar-header'>
      <TimeCalendarRow>
        <TimeCalendarLeftPart>
          <div className='time-calendar-left-header-container'>
            <div className='header-title'>Task name</div>
          </div>
        </TimeCalendarLeftPart>
        <TimeCalendarRightPart>
          {
            userCalendar.days.map(day => {
              return (
                <TimeCalendarHeaderCell
                  key={day.day}
                  day={new Date(day.day).getDate()}
                  dayOfWeek={day.dayOfWeek.slice(0, 2)}
                />
              )
            })
          }
        </TimeCalendarRightPart>
      </TimeCalendarRow>
    </div>
  )
}

export { TimeCalendarHeader };
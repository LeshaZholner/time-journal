import { TimeCalendarCell } from "./TimeCalendarCell";
import './styles.scss';

const TimeCalendarWorkloadCell = ({ value }) => {
  return (
    <TimeCalendarCell
      classes='time-calendar-cell-wrapper-workload'
    >
      <div className='time-calendar-workload-cell'>
        <input
          className='time-calendar-workload-cell-input'
          defaultValue={value}
        />
      </div>
    </TimeCalendarCell>
  )
}

export { TimeCalendarWorkloadCell };
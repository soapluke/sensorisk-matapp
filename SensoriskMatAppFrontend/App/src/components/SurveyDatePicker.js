import React from 'react';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import '../styles/datepicker.css';
import isAfter from "date-fns/isAfter";

export default class SurveyDatePicker extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            startDate: undefined,
            endDate: undefined
        };
    }

    onDateChange = async ({ startDate, endDate }) => {
        startDate = startDate || this.state.startDate;
        endDate = endDate || this.state.endDate;
        
        if (isAfter(startDate, endDate)) {
            endDate = startDate;
        }

        await this.setState({ startDate, endDate });

        this.props.onDateChange({
            startDate: this.state.startDate,
            endDate: this.state.endDate
        });
    };

    handleChangeStart = startDate => this.onDateChange({ startDate });

    handleChangeEnd = endDate => this.onDateChange({ endDate });


    render() {
        return (
            <div>
                <DatePicker
                    className="datepicker"
                    placeholderText="Click to select a start date"
                    selected={this.state.startDate}
                    selectsStart
                    startDate={this.state.startDate}
                    minDate={new Date()}
                    endDate={this.state.endDate}
                    onChange={this.handleChangeStart}
                    showWeekNumbers
                    showTimeSelect
                    timeFormat="HH:mm"
                    dateFormat="MMMM d, yyyy HH:mm"
                />

                <DatePicker
                    className="datepicker"
                    placeholderText="Click to select a end date"
                    selected={this.state.endDate}
                    selectsEnd
                    startDate={this.state.startDate}
                    endDate={this.state.endDate}
                    onChange={this.handleChangeEnd}
                    showWeekNumbers
                    showTimeSelect
                    timeFormat="HH:mm"
                    dateFormat="MMMM d, yyyy HH:mm"
                />
            </div>
            );
    }
};
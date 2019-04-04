import React from 'react';
import { connect } from 'react-redux';
import { List } from 'semantic-ui-react';
import filterFreeTextQuestionByChapterID from '../filters/filterFreeTextQuestionByChapterID';
import filterMultiChoiceQuestionByChapterID from '../filters/filterMultiChoiceQuestionsByChapterID';

export const QuestionList = (props) => {
    return (
        <div>
            <List celled>
                {props.freeTextQuestions.length === 0 ? (
                    <p>No free text questions added.</p>
                ) : (
                props.freeTextQuestions.map((ftQuestion, i) => {
                        return <List.Item as="h3" key={ftQuestion[i]}>{ftQuestion.question}</List.Item>
                    })
                )}
                {props.multiChoiceQuestions.length === 0 ? (
                    <p>No multi choice questions added.</p>
                ) : (
                props.multiChoiceQuestions.map((mcQuestion, i) => {
                    return (
                            <List.Item as="h3" key={mcQuestion[i]}>{mcQuestion.question}
                                <List.List>
                                {
                                    props.multiChoiceQuestions[i].options.map((option) => {
                                        return <List.Item as="h5" key={option}>{option}</List.Item>
                                    })
                                }
                                </List.List>
                            </List.Item>
                        )
                    })
                )}
            </List>
        </div>
    );
}

const mapStateToProps = (state, props) => ({
    // eslint-disable-next-line
    freeTextQuestions: filterFreeTextQuestionByChapterID(state.freeTextQuestions, props.chapterID),
    multiChoiceQuestions: filterMultiChoiceQuestionByChapterID(state.multiChoiceQuestions, props.chapterID)
});

export default connect(mapStateToProps)(QuestionList);
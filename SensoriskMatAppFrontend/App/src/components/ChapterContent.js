import React from 'react';
import { connect } from 'react-redux';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import QuestionModal from '../components/QuestionModal';
import ChapterQuestions from '../components/ChapterQuestions';
import '../styles/content-container.css';

export const ChapterContent = (props) => {
    return (
        <div>
                {props.chapters.length === 0 ? (
                    <p>No chapters added.</p>
                ) : (
                    props.chapters.map((chapter) => {
                        return (
                            <div>
                                <Divider />
                                    <Typography variant="h5" gutterBottom key={chapter.chapterID}>{chapter.title}</Typography>
                                    <div>
                                        <ChapterQuestions chapterID={chapter.chapterID} />
                                    </div>
                                    <div>
                                        <QuestionModal chapterID={chapter.chapterID} />
                                    </div>
                                <Divider />
                            </div>
                        )
                    })
                )}
        </div>
    );
}

const mapStateToProps = (state) => ({
    // eslint-disable-next-line
    chapters: state.chapters
});

export default connect(mapStateToProps)(ChapterContent);
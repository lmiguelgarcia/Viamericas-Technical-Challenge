import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import './styles.css';
import { agencyActions } from '../_actions';

class HomePage extends React.Component {
    
    constructor(props) {
        super(props);
        this.state = {
          agencies: {items:[]}
        };
        this.sortConfig={
            key:'',
            direction:''
        }

        this.sorted=false;
      }
    componentDidMount() {        
        this.props.dispatch(agencyActions.getAllAgencies());

        this.colorStatus.bind(this);
    }

    colorStatus(status) {
        if (status === 'Closed') {
            return 'agency-closed';
        } else {
            return '';
        }
    }

    compareByAsc(key) {
        return function(a, b) {
          if (a[key] < b[key]) return -1;
          if (a[key] > b[key]) return 1;
          return 0;
        };
      }
    
      compareByDesc(key) {
        return function(a, b) {
          if (a[key] < b[key]) return 1;
          if (a[key] > b[key]) return -1;
          return 0;
        };
      }
    
      sortBy(key) {
        let arrayCopy = [... this.sorted==false? this.props.agencies.items: this.state.agencies.items];        
        const arrInStr = JSON.stringify(arrayCopy);
        arrayCopy.sort(this.compareByAsc(key));
        this.sortConfig.direction='ascending';
        const arrInStr1 = JSON.stringify(arrayCopy);
        
        if (arrInStr === arrInStr1) {
          arrayCopy.sort(this.compareByDesc(key));
          this.sortConfig.direction='descending';
        }
        
        this.sorted=true;
        this.sortConfig.key=key;
        this.setState({ agencies:{items:arrayCopy}});
      }

    getClassNamesFor (name){
        if (!this.sortConfig) {
          return;
        }
        return this.sortConfig.key === name ? this.sortConfig.direction : undefined;
      }

    render() {
        
        const {  agencies } = this.sorted==false? this.props : this.state;
        return (
            <div>
                <h1>Viamericas Agencies</h1>
                {agencies.items &&
                    <table>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th onClick={() => this.sortBy('id')} className={this.getClassNamesFor('id')}>Id</th>
                                <th onClick={() => this.sortBy('name')} className={this.getClassNamesFor('name')}>Name</th>
                                <th onClick={() => this.sortBy('status')} className={this.getClassNamesFor('status')}>Status</th>
                                <th onClick={() => this.sortBy('city')} className={this.getClassNamesFor('city')}>City</th>
                            </tr>
                        </thead>
                        <tbody>
                            {agencies.items.map((agency, index) => {
                                return (
                                    <tr key={index} className={this.colorStatus(agency.status)}>
                                        <td>{index + 1}</td>
                                        <td>{agency.id}</td>
                                        <td>{agency.name}</td>
                                        <td>{agency.status}</td>
                                        <td>{agency.city}</td>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </table>
                }
                <br></br>
                <p>
                    <Link to="/login">Logout</Link>
                </p>
            </div>
        );
    }
}

function mapStateToProps(state) {
    const { agencies } = state;
    return {
        agencies
    };
}

const connectedHomePage = connect(mapStateToProps)(HomePage);
export { connectedHomePage as HomePage };
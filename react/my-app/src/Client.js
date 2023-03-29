
import React,{Component} from 'react';
import {Table} from 'react-bootstrap';

import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddClientModal} from './AddClientModal';
import {EditClientModal} from './EditClientModal';

export class Client extends Component{

    constructor(props){
        super(props);
        this.state={clients:[], addModalShow:false, editModalShow:false}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API+'AllClients')
        .then(response=>response.json())
        .then(data=>{
            this.setState({clients:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteClient(clientid){
        if(window.confirm('Are you sure?')){
            fetch(process.env.REACT_APP_API+'remove/'+clientid,{
                method:'DELETE',
                header:{'Accept':'application/json',
            'Content-Type':'application/json'}
            })
        }
    }
    render(){
        const {clients, clid,clname,clsurname ,clphone, clemail}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
            <div >
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>ClientId</th>
                        <th>ClientName</th>
                        <th>ClientSurName</th>
                        <th>ClientPhone</th>
                        <th>ClientEmail</th>
                      
                        <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {clients.map(cli=>
                            <tr key={cli.clientId}>
                                <td>{cli.clientId}</td>
                                <td>{cli.clientName}</td>
                                <td>{cli.clientSurName}</td>
                                <td>{cli.clientPhone}</td>
                                <td>{cli.clientEmail}</td>
                                <td>
<ButtonToolbar>
    <Button className="mr-2" variant="info"
    onClick={()=>this.setState({editModalShow:true,
        clid:cli.clientId,clname:cli.clientName,clsurname:cli.clientSurName, clphone:cli.clientPhone,clemail:cli.clientEmail })}>
            Edit
        </Button>

        <Button className="mr-2" variant="danger"
    onClick={()=>this.deleteClient(cli.clientId)}>
            Delete
        </Button>

        <EditClientModal show={this.state.editModalShow}
        onHide={editModalClose}
        clid={clid}
        clname={clname}
        clsurname={clsurname}
        clphone={clphone}
        clemail={clemail}
        />
</ButtonToolbar>

                                </td>

                            </tr>)}
                    </tbody>

                </Table>

                <ButtonToolbar>
                    <Button
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Client</Button>

                    <AddClientModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}

import { useContext, useEffect } from "react";
import AuthContext from "./AuthContext";


function Logout() {
    const { logout } = useContext(AuthContext);

    useEffect(() => {
        logout();
    }, [logout]);

    return null;
}

export default Logout;